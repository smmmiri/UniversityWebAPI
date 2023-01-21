using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CourseController : BaseController
    {
        private readonly IAllServices _allServices;

        public CourseController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(AddCourseCommand command)
        {
            try
            {
                await _allServices.CourseService.AddCourse(command, UserId, UniversityId);
                return OkResult("درس با موفقیت ساخته شد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات ساختن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddScore(AddScoreCommand command)
        {
            try
            {
                await _allServices.CourseService.AddScore(command, UserId, UniversityId);
                return OkResult("نمره با موفقیت اضافه شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
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
        public async Task<IActionResult> GetListOnlyCourse([FromQuery] SearchCommand command)
        {
            try
            {
                var result = await _allServices.CourseService
                    .GetListCourse(command.PageNumber, command.PageSize, command.Search, UniversityId);
                return OkResult("نتیجه‌ی درس‌های جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListCourse([FromQuery] SearchAndSemesterCommand command)
        {
            try
            {
                var result = await _allServices.CourseService
                    .GetListCourse(command.PageNumber, command.PageSize, command.Search, command.SemesterId, UniversityId);
                return OkResult("نتیجه‌ی درس‌های جستجو شده همراه استاد و ترم آن‌ها", result.List, result.Count);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListCourseOfStudent([FromQuery] SemesterAndIdCommand command)
        {
            try
            {
                var result = await _allServices.CourseService
                    .GetListCourseOfStudent(command.PageNumber, command.PageSize, command.Id,command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی درس‌های یک دانشجو همراه استاد و ترم آن‌ها", result.List, result.Count);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListCourseOfProfessor([FromQuery] SemesterAndIdCommand command)
        {
            try
            {
                var result = await _allServices.CourseService
                    .GetListCourseOfProfessor(command.PageNumber, command.PageSize, command.Id, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی درس‌های یک استاد همراه ترم آن‌ها", result.List, result.Count);
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateScore(UpdateScoreCommand command)
        {
            try
            {
                await _allServices.CourseService.UpdateScore(command, UserId, UniversityId);
                return OkResult("نمره با موفقیت بروزرسانی شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCourse(UpdateCourseCommand command)
        {
            try
            {
                await _allServices.CourseService.UpdateCourse(command, UserId, UniversityId);
                return OkResult("درس با موفقیت بروزرسانی شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("درس تعریف نشده است");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
        
        [HttpDelete]
        public async Task<IActionResult> RemoveCourse(string courseId)
        {
            try
            {
                await _allServices.CourseService.RemoveCourse(new(courseId), UserId, UniversityId);
                return OkResult("درس با موفقیت حذف شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidDataException ex)
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
