using Domain;
using Message.Commands;

namespace Service.Interfaces
{
    public interface IUserRoleService
    {
        Task GrantRoleToUser(GrantCommand grantCommand);
    }
}
