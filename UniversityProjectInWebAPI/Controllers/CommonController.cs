using Message.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UniversityProjectInWebAPI.Controllers
{
    [ApiController]
    public class CommonController : ControllerBase
    {
        public const string emptyGuid = "00000000-0000-0000-0000-000000000000";

        [NonAction]
        public OkObjectResult OkResult(string message = "", object content = null, int total = 0)
        {
            OkDTO dto = new()
            {
                Message = message,
                Content = content,
                Total = total
            };
            return new OkObjectResult(dto);
        }
    }
}