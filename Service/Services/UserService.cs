using Domain;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Repository;
using Service.Interfaces;

namespace Service.ControllersServices
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUser(AddUserCommand command, Guid userId)
        {
            await Task.Run(() =>
            {
                if (_unitOfWork.UserRepository.CheckUserExistence(command.Email))
                    throw new InvalidDataException("کاربر وجود دارد");

                if (!_unitOfWork.UniversityRepository.CheckUniversityExistence(command.UniversityId))
                    throw new NullReferenceException("دانشگاه تعریف نشده است");

                AppUser user = _unitOfWork.UserRepository.AddUser(command);
                user.CreatorId = userId;
                _unitOfWork.UserRepository.Add(user);
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<UserDTO>> GetListUser(int pageNumber, int pageSize, string search)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.UserRepository.GetListUser(search);

                GetReturnDTO<UserDTO> dto = new()
                {
                    List = result.ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task UpdateUser(UpdateUserCommand userCommand, Guid userId)
        {
            await Task.Run(() =>
            {
                AppUser user = _unitOfWork.UserRepository.GetById(userCommand.Id.ToString());

                user.FirstName = userCommand.FirstName;
                user.LastName = userCommand.LastName;
                user.Email = userCommand.Email;
                user.NormalizedEmail = userCommand.Email.ToUpper();
                user.UserName = userCommand.Email;
                user.NormalizedUserName = userCommand.Email.ToUpper();
                PasswordHasher<AppUser> passwordHasher = new();
                user.PasswordHash = passwordHasher.HashPassword(user, userCommand.Password);
                user.ModifierId = userId;
                user.ModificationDate = DateTime.Now;
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveUser(string id, Guid userId)
        {
            await Task.Run(() =>
            {
                AppUser user = _unitOfWork.UserRepository.GetById(id);

                _unitOfWork.UserRepository.RemoveUser(user, userId);
                _unitOfWork.Complete();
            });
        }
    }
}
