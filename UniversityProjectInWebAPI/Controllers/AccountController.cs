using Message.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AccountController : CommonController
    {
        private readonly IAllServices _allServices;

        public AccountController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            try
            {
                var result = await _allServices.AccountService.Login(command);
                return OkResult("ورود با موفقیت انجام شد", result);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        public async Task Logout()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            await _allServices.AccountService.Logout(GetUserId(), token);
        }

        private string GetUserId()
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            return jwtSecurityToken.Claims.Where(c => c.Type == ClaimTypes.NameIdentifier).FirstOrDefault()?.Value;
        }
    }
}
