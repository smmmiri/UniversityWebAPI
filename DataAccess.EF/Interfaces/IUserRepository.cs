using Domain;
using Message.Commands;
using Message.DTOs;

namespace Repository.Interfaces
{
    public interface IUserRepository : IGenericRepository<AppUser>
    {
        bool CheckUserExistence(string userEmail);

        AppUser AddUser(AddUserCommand userCommand);

        IEnumerable<UserDTO> GetListUser(string search);

        AppUser GetById(string userId);

        void RemoveUser(AppUser user, Guid userId);
    }
}
