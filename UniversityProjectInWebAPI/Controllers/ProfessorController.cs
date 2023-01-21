using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProfessorController : BaseController
    {
        private readonly IAllServices _allServices;
        public ProfessorController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddOnlyProfessor(AddOnlyProfessorCommand command)
        {
            try
            {
                await _allServices.ProfessorService.AddOnlyProfessor(command, UserId, UniversityId);
                return OkResult("استاد با موفقیت ساخته شد");
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
        public async Task<IActionResult> AddProfessor(AddProfessorCommand command)
        {
            try
            {
                await _allServices.ProfessorService.AddProfessor(command, UserId, UniversityId);
                return OkResult("استاد با موفقیت ساخته شد");
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
        public async Task<IActionResult> AddProfessorToCourse(AddProfessorToCourseCommand command)
        {
            try
            {
                await _allServices.ProfessorService.AddProfessorToCourse(command, UserId, UniversityId);
                return OkResult("استاد با موفقیت به درس اضافه شد");
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
                throw new Exception("مشکلی در عملیات اضافه کردن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> AddSalaryForProfessor(AddSalaryForProfessorCommand command)
        //{
        //    try
        //    {
        //        await _allServices.ProfessorService.AddSalaryForProfessor(command, UniversityId, UserId);
        //        return OkResult("دستمزد با موفقیت اضافه شد");
        //    }
        //    catch (NullReferenceException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (InvalidDataException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw new Exception("مشکلی در عملیات اضافه کردن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> GetListOnlyProfessor([FromQuery] SearchCommand command)
        {
            try
            {
                var result = await _allServices.ProfessorService
                    .GetListProfessor(command.PageNumber, command.PageSize, command.Search, UniversityId);
                return OkResult("نتیجه‌ی استاد‌های جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetListProfessor([FromQuery] SearchAndSemesterCommand command)
        {
            try
            {
                var result = await _allServices.ProfessorService
                    .GetListProfessor(command.PageNumber, command.PageSize, command.Search, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی استاد‌های جستجو شده همراه دستمزد، درس و ترم آن‌ها", result.List, result.Count);
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
        public async Task<IActionResult> GetListProfessorOfCourse([FromQuery] SemesterAndIdCommand command)
        {
            try
            {
                var result = await _allServices.ProfessorService
                    .GetListProfessorOfCourse(command.PageNumber, command.PageSize, command.Id, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی استاد‌های یک درس همراه دستمزد و ترم آن‌ها", result.List, result.Count);
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
        public async Task<IActionResult> GetListProfessorOfStudent([FromQuery] SemesterAndIdCommand command)
        {
            try
            {
                var result = await _allServices.ProfessorService
                    .GetListProfessorOfStudent(command.PageNumber, command.PageSize, command.Id, command.SemesterId, 
                    UniversityId);
                return OkResult("نتیجه‌ی استاد‌های یک دانشجو همراه دستمزد، درس و ترم آن‌ها", result.List, result.Count);
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
        public async Task<IActionResult> UpdateProfessor(UpdateProfessorCommand command)
        {
            try
            {
                await _allServices.ProfessorService.UpdateProfessor(command, UserId, UniversityId);
                return OkResult("استاد با موفقیت بروزرسانی شد");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException)
            {
                return BadRequest("استاد وجود ندارد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
        
        [HttpDelete]
        public async Task<IActionResult> RemoveProfessor(string professorId)
        {
            try
            {
                await _allServices.ProfessorService.RemoveProfessor(new(professorId), UserId, UniversityId);
                return OkResult("استاد با موفقیت حذف شد");
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
        public async Task<IActionResult> DeleteProfessorFromCourse(DeleteProfessorFromCourseCommand command)
        {
            try
            {
                await _allServices.ProfessorService.DeleteProfessorFromCourse(command, UniversityId);
                return OkResult("استاد با موفقیت از درس حذف شد");
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
                throw new Exception("مشکلی در عملیات حذف کردن رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}