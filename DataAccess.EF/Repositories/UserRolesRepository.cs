using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRolesRepository : GenericRepository<IdentityUserRole<string>>, IUserRolesRepository
    {
        public UserRolesRepository(AcademyDbContext academy) : base(academy)
        {
        }
    }
}
