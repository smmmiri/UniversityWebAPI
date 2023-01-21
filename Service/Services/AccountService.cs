using Domain;
using Message.Commands;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.ControllersServices
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration configuration, ILogger logger, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> Login(LoginCommand userCommand)
        {
            string token;
            var user = await _userManager.FindByNameAsync(userCommand.Email);

            if (await ValidateUser(userCommand))
            {
                _logger.LogInformation("The user with id: {userId} was Logged in.", user.Id);
                token = await CreateToken(userCommand);
            }
            else
            {
                if(user != null)
                    _logger.LogWarning("The user with id {userId} had an unsuccessful attempt to log in to the system", 
                        user.Id);
                throw new InvalidDataException("نام کاربری یا رمز عبور اشتباه است");
            }

            return token;
        }

        public async Task Logout(string UserId, string token)
        {
            _unitOfWork.LogoutRepository.AddToBlackList(token);
            _logger.LogInformation("The user with Id: {userId} was Logged out.", UserId);
            await _signInManager.SignOutAsync();
        }

        private async Task<bool> ValidateUser(LoginCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.Email);
            return user != null && await _userManager.CheckPasswordAsync(user, command.Password);
        }

        private async Task<string> CreateToken(LoginCommand command)
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims(command);
            var token = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("Jwt:Key").Value));
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims(LoginCommand userCommand)
        {
            var user = _userManager.Users.Where(u => u.UserName == userCommand.Email).Single();

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.GivenName, user.UniversityId.ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            var rolesClaim = string.Join(",", roles);
            claims.Add(new Claim(ClaimTypes.Role, rolesClaim));

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            return new JwtSecurityToken(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration.GetSection("Jwt:Lifetime").Value)),
                signingCredentials: signingCredentials
                );
        }
    }
}