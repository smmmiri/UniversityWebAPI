using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class StudentController : BaseController
    {
        private readonly IAllServices _allServices;
        public StudentController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddOnlyStudent(AddOnlyStudentCommand command)
        {
            try
            {
                await _allServices.StudentService.AddOnlyStudent(command, UserId, UniversityId);
                return OkResult("دانشجو با موفقیت ساخته شد");
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

        [HttpPost]
        public async Task<IActionResult> AddStudent(AddStudentCommand command)
        {
            try
            {
                await _allServices.StudentService.AddStudent(command, UserId, UniversityId);
                return OkResult("دانشجو با موفقیت ساخته شد");
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

        [HttpPost]
        public async Task<IActionResult> AddStudentToCourse(AddStudentToCourseCommand command)
        {
            try
            {
                await _allServices.StudentService.AddStudentToCourse(command, UniversityId);
                return OkResult("دانشجو با موفقیت به درس اضافه شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات اضافه کردن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListOnlyStudent([FromQuery] SearchCommand command)
        {
            try
            {
                var result = await _allServices.StudentService
                    .GetListStudent(command.PageNumber, command.PageSize, command.Search, UniversityId);
                return OkResult("نتیجه‌ی دانشجوهای جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListStudentOfCourse([FromQuery] SemesterAndIdCommand command)
        {
            try
            {
                var result = await _allServices.StudentService
                    .GetListStudentOfCourse(command.PageNumber, command.PageSize, command.Id, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی دانشجو‌های یک درس همراه استاد و ترم آن‌", result.List, result.Count);
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
        public async Task<IActionResult> GetScoreOfStudentInTheCourse([FromQuery] GetScoreOfStudentInTheCourseCommand command)
        {
            try
            {
                var result = await _allServices.StudentService
                    .GetScoreOfStudentInTheCourse(command.StudentId, command.CourseId, command.SemesterId, UniversityId);
                return OkResult("نتیجه‌ی نمره‌ی دانشجو در یک درس همراه استاد و ترم آن", result, 1);
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
        public async Task<IActionResult> GetListStudentOfProfessor([FromQuery] SemesterAndIdCommand command)
        {
            try
            {
                var result = await _allServices.StudentService
                    .GetListStudentOfProfessor(command.PageNumber, command.PageSize, command.Id, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی دانشجو‌های یک استاد همراه درس و ترم آن‌ها", result.List, result.Count);
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
        public async Task<IActionResult> GetListStudent([FromQuery] SearchAndSemesterCommand command)
        {
            try
            {
                var result = await _allServices.StudentService
                    .GetListStudent(command.PageNumber, command.PageSize, command.Search, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی دانشجو‌های جستجو شده همراه استاد و درس و ترم آن‌ها", result.List, result.Count);
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
        public async Task<IActionResult> UpdateStudent(UpdateStudentCommand command)
        {
            try
            {
                await _allServices.StudentService.UpdateStudent(command, UserId, UniversityId);
                return OkResult("دانشجو با موفقیت بروزرسانی شد");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException)
            {
                return BadRequest("دانشجو یا درس وجود ندارند");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveStudent(string studentId)
        {
            try
            {
                await _allServices.StudentService.RemoveStudent(new(studentId), UserId, UniversityId);
                return OkResult("دانشجو با موفقیت حذف شد");
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

        [HttpDelete]
        public async Task<IActionResult> DeleteStudentFromCourse(DeleteStudentFromCourseCommand command)
        {
            try
            {
                await _allServices.StudentService.DeleteStudentFromCourse(command, UniversityId);
                return OkResult("دانشجو با موفقیت از درس حذف شد");
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات حذف کردن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}
