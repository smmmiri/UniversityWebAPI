using Domain;
using Message.Commands;

namespace Repository.Interfaces
{
    public interface IRoleRepository : IGenericRepository<AppRole>
    {
        bool CheckRoleExistence(string roleName);
        
        AppRole AddRole(AddRoleCommand roleCommand);

        AppRole GetById(string roleId);
        
        IEnumerable<AppRole> GetListRole(string search);

        void RemoveRole(AppRole role, Guid userId);
    }
}
