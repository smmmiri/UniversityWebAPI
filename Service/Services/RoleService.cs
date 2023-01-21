using Domain;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Repository;
using Service.Interfaces;

namespace Service.ControllersServices
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddRole(AddRoleCommand roleCommand, Guid userId)
        {
            await Task.Run(() =>
            {
                if (_unitOfWork.RoleRepository.CheckRoleExistence(roleCommand.NormalizedName))
                    throw new InvalidDataException("نقش وجود دارد");

                AppRole role = _unitOfWork.RoleRepository.AddRole(roleCommand);
                role.CreatorId = userId;
                _unitOfWork.RoleRepository.Add(role);
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<RoleDTO>> GetListRole(int pageNumber, int pageSize, string search)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.RoleRepository.GetListRole(search);

                GetReturnDTO<RoleDTO> dto = new()
                {
                    List = result
                    .Select(r => new RoleDTO
                    {
                        Id = r.Id,
                        Name = r.Name,
                        NormalizedName = r.NormalizedName
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task UpdateRole(UpdateRoleCommand roleCommand, Guid userId)
        {
            await Task.Run(() =>
            {
                AppRole role = _unitOfWork.RoleRepository.GetById(roleCommand.Id.ToString());

                role.Name = roleCommand.Name;
                role.NormalizedName = roleCommand.NormalizedName;
                role.ModifierId = userId;
                role.ModificationDate = DateTime.Now;
                _unitOfWork.RoleRepository.Update(role);
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveRole(string roleId, Guid userId)
        {
            await Task.Run(() =>
            {
                AppRole role = _unitOfWork.RoleRepository.GetById(roleId);

                _unitOfWork.RoleRepository.RemoveRole(role, userId);
                _unitOfWork.Complete();
            });
        }
    }
}
