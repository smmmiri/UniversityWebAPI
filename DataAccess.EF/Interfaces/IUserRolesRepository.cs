using Microsoft.AspNetCore.Identity;

namespace Repository.Interfaces
{
    public interface IUserRolesRepository : IGenericRepository<IdentityUserRole<string>>
    {
    }
}
