using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class RoleController : AdminBaseController
    {
        private readonly IAllServices _allServices;

        public RoleController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleCommand command)
        {
            try
            {
                await _allServices.RoleService.AddRole(command, UserId);
                return OkResult("نقش با موفقیت ساخته شد");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات ساختن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetRole([FromQuery] SearchCommand command)
        {
            try
            {
                var result = 
                    await _allServices.RoleService.GetListRole(command.PageNumber, command.PageSize, command.Search);
                return OkResult("نتیجه‌ی نقش‌های جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRole(UpdateRoleCommand command)
        {
            try
            {
                await _allServices.RoleService.UpdateRole(command, UserId);
                return OkResult("نقش با موفقیت بروزرسانی شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("نقش وجود ندارد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRole(string roleId)
        {
            try
            {
                await _allServices.RoleService.RemoveRole(roleId, UserId);
                return OkResult("نقش با موفقیت حذف شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("نقش وجود ندارد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات حذف رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}
