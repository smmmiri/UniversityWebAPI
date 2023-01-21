using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace UniversityProjectInWebAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AdminBaseController : CommonController
    {
        public Guid UserId => new(TokenExtraction(ClaimTypes.NameIdentifier).ToString());
        public Guid UniversityId
        {
            get
            {
                var result = TokenExtraction(ClaimTypes.GivenName);
                return result == null ? Guid.Empty : new(result.ToString());
            }
        }

        private object TokenExtraction(string claimType)
        {
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            return jwtSecurityToken.Claims.Where(c => c.Type == claimType).FirstOrDefault()?.Value;
        }
    }
}