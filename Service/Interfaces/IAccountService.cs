using Message.Commands;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<string> Login(LoginCommand userCommand);
        Task Logout(string UserId, string token);
    }
}
