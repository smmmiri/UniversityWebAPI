using Domain;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UserRepository : GenericRepository<AppUser>, IUserRepository
    {
        public UserRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool CheckUserExistence(string userEmail)
        {
            return _academy.Users.Any(u => u.Email == userEmail);
        }

        public AppUser AddUser(AddUserCommand userCommand)
        {
            AppUser user = new()
            {
                FirstName = userCommand.FirstName,
                LastName = userCommand.LastName,
                UserName = userCommand.Email,
                NormalizedUserName = userCommand.Email.ToUpper(),
                Email = userCommand.Email,
                NormalizedEmail = userCommand.Email.ToUpper(),
                UniversityId = userCommand.UniversityId
            };

            PasswordHasher<AppUser> passwordHasher = new();
            user.PasswordHash = passwordHasher.HashPassword(user, userCommand.Password); 

            return user;
        }

        public AppUser GetById(string userId)
        {
            return _academy.Users.Where(u => u.Id == userId).SingleOrDefault();
        }

        public IEnumerable<UserDTO> GetListUser(string search)
        {
            return _academy.Users
                .Where(r => (r.UserName + r.FirstName + " " + r.LastName).Contains(search))
                .Join(_academy.Universities,
                user => user.UniversityId,
                university => university.Id,
                (user, university) => new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    UniversityId = user.UniversityId ?? Guid.Empty,
                    UniversityName = university.Name ?? ""
                });
        }

        public void RemoveUser(AppUser user, Guid userId)
        {
            user.IsActive = false;
            user.ModifierId = userId;
            user.ModificationDate = DateTime.Now;
        }
    }
}
