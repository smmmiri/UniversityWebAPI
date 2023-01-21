using Message.Commands;
using Microsoft.AspNetCore.Identity;
using Repository;
using Service.Interfaces;

namespace Service.ControllersServices
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task GrantRoleToUser(GrantCommand grantCommand)
        {
            await Task.Run(() =>
            {
                var role = _unitOfWork.RoleRepository.GetById(grantCommand.RoleId);
                var user = _unitOfWork.UserRepository.GetById(grantCommand.UserId);

                if (user == null)
                    throw new NullReferenceException("کاربر تعریف نشده است");

                if (role == null)
                    throw new NullReferenceException("نقش تعریف نشده است");

                IdentityUserRole<string> userRole = new()
                {
                    RoleId = role.Id,
                    UserId = user.Id
                };

                _unitOfWork.UserRolesRepository.Add(userRole);
                _unitOfWork.Complete();
            });
        }
    }
}