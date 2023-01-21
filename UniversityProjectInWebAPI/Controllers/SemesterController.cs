using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SemesterController : BaseController
    {
        private readonly IAllServices _allServices;

        public SemesterController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddSemester(AddSemesterCommand command)
        {
            try
            {
                await _allServices.SemesterService.AddSemester(command, UserId, UniversityId);
                return OkResult("ترم با موفقیت اضافه شد");
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
        public async Task<IActionResult> GetSemester([FromQuery] SearchCommand command)
        {
            try
            {
                var result = await _allServices.SemesterService
                    .GetListSemesters(command.PageNumber, command.PageSize, command.Search, UniversityId);
                return OkResult("نتیجه‌ی ترم‌های جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSemester(UpdateSemesterCommand command)
        {
            try
            {
                await _allServices.SemesterService.UpdateSemester(command, UserId, UniversityId);
                return OkResult("ترم با موفقیت بروزرسانی شد");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException)
            {
                return BadRequest("ترم تعریف نشده است");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSemester(string semesterId)
        {
            try
            {
                await _allServices.SemesterService.RemoveSemester(new(semesterId), UserId, UniversityId);
                return OkResult("ترم با موفقیت حذف شد");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException)
            {
                return BadRequest("ترم تعریف نشده است");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات حذف کردن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}
