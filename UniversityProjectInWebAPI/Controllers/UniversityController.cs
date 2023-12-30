using Message.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UniversityController : AdminBaseController
    {
        private readonly IAllServices _allServices;

        public UniversityController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddUniversityAsync(AddUniversityCommand command)
        {
            try
            {
                await _allServices.UniversityService.AddUniversityAsync(command, UserId);
                return OkResult("دانشگاه با موفقیت ساخته شد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات ساختن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetListUniversity([FromQuery] SearchCommand command)
        {
            try
            {
                var result = await _allServices.UniversityService
                    .GetListUniversity(command.PageNumber, command.PageSize, command.Search);
                return OkResult("نتیجه‌ی دانشگاه‌های جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateUniversityForAdmin(UpdateUniversityForAdminCommand command)
        {
            try
            {
                await _allServices.UniversityService.UpdateUniversityForAdmin(command, UserId);
                return OkResult("دانشگاه با موفقیت بروزرسانی شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("دانشگاه تعریف نشده است");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPut]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateUniversityForUser(UpdateUniversityForUserCommand command)
        {
            try
            {
                await _allServices.UniversityService.UpdateUniversityForUser(command, UserId, UniversityId);
                return OkResult("دانشگاه با موفقیت بروزرسانی شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("دانشگاه تعریف نشده است");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RemoveUniversity(string universityId)
        {
            try
            {
                await _allServices.UniversityService.RemoveUniversity(new(universityId), UserId);
                return OkResult("دانشگاه با موفقیت حذف شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات حذف رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}
