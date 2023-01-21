using Message.Commands;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace UniversityProjectInWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    public class UserController : AdminBaseController
    {
        private readonly IAllServices _allServices;

        public UserController(IAllServices allServices)
        {
            _allServices = allServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserCommand command)
        {
            try
            {
                await _allServices.UserService.AddUser(command, UserId);
                return OkResult("کاربر با موفقیت ساخته شد");
            }
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NullReferenceException ex)
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
        public async Task<IActionResult> GetUser([FromQuery] SearchCommand command)
        {
            try
            {
                var result = await _allServices.UserService
                    .GetListUser(command.PageNumber, command.PageSize, command.Search);
                return OkResult("نتیجه‌ی کاربر‌های جستجو شده", result.List, result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات جستجو رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            try
            {
                await _allServices.UserService.UpdateUser(command, UserId);
                return OkResult("کاربر با موفقیت بروزرسانی شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("کاربر وجود ندارد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات بروزرسانی رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveUser(string userId)
        {
            try
            {
                await _allServices.UserService.RemoveUser(userId, UserId);
                return OkResult("کاربر با موفقیت حذف شد");
            }
            catch (NullReferenceException)
            {
                return BadRequest("کاربر وجود ندارد");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception("مشکلی در عملیات حذف رخ داده است، لطفا با پشتیبانی تماس بگیرید");
            }
        }
    }
}