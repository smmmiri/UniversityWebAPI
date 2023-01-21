using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface IRoleService
    {
        Task AddRole(AddRoleCommand roleCommand, Guid userId);
        
        Task<GetReturnDTO<RoleDTO>> GetListRole(int pageNumber, int pageSize, string search);
        
        Task UpdateRole(UpdateRoleCommand roleCommand, Guid userId);
        
        Task RemoveRole(string id, Guid userId);
    }
}
