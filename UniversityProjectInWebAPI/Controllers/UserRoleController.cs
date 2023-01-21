using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserRoleController : AdminBaseController
    {
        private readonly IAllServices _allServices;

        public UserRoleController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> GrantRoleToUser(GrantCommand command)
        {
            try
            {
                await _allServices.UserRoleService.GrantRoleToUser(command);
                return OkResult("نقش با موفقیت متصل شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات اتصال رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}