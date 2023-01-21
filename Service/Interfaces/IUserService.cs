using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface IUserService
    {
        Task AddUser(AddUserCommand userCommand, Guid userId);

        Task<GetReturnDTO<UserDTO>> GetListUser(int pageNumber, int pageSize, string search);

        Task UpdateUser(UpdateUserCommand userCommand, Guid userId);

        Task RemoveUser(string id, Guid userId);
    }
}
