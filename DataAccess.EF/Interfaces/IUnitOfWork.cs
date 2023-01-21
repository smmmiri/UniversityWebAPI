using Repository.Interfaces;

namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUniversityRepository UniversityRepository { get; }
        ISemesterRepository SemesterRepository { get; }
        ICourseRepository CourseRepository { get; }
        IStudentRepository StudentRepository { get; }
        IProfessorRepository ProfessorRepository { get; }
        IProfessorRelationsRepository ProfessorRelationsRepository { get; }
        IStudentRelationsRepository StudentRelationsRepository { get; }
        IAccountRepository AccountRepository { get; } 
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRolesRepository UserRolesRepository { get; }
        IUniversityProfessorRepository UniversityProfessorRepository { get; }
        IUniversityStudentRepository UniversityStudentRepository { get; }
        ILogoutRepository LogoutRepository { get; }
        int Complete();
    }
}
