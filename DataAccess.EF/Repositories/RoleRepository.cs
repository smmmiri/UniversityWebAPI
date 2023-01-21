using Domain;
using Message.Commands;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class RoleRepository : GenericRepository<AppRole>, IRoleRepository
    {
        public RoleRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool CheckRoleExistence(string roleName)
        {
            return _academy.Roles.Any(r => r.NormalizedName == roleName);
        }

        public AppRole AddRole(AddRoleCommand roleCommand)
        {
            AppRole role = new()
            {
                Name = roleCommand.Name,
                NormalizedName = roleCommand.NormalizedName
            };
            return role;
        }

        public AppRole GetById(string roleId)
        {
            return _academy.Roles.Where(r => r.Id == roleId).SingleOrDefault();
        }
        public IEnumerable<AppRole> GetListRole(string search)
        {
            return _academy.Roles.Where(r => r.Name.Contains(search));
        }

        public void RemoveRole(AppRole role, Guid userId)
        {
            role.IsActive = false;
            role.ModifierId = userId;
            role.ModificationDate = DateTime.Now;
        }
    }
}
