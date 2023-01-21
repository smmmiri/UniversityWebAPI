using Repository.Interfaces;
using Repository.Repositories;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AcademyDbContext _academy;

        public UnitOfWork(AcademyDbContext academy)
        {
            _academy = academy;
            UniversityRepository = new UniversityRepository(_academy);
            SemesterRepository = new SemesterRepository(_academy);
            CourseRepository = new CourseRepository(_academy);
            StudentRepository = new StudentRepository(_academy);
            ProfessorRepository = new ProfessorRepository(_academy);
            StudentRelationsRepository = new StudentRelationsRepository(_academy);
            ProfessorRelationsRepository = new ProfessorRelationsRepository(_academy);
            AccountRepository = new AccountRepository(_academy);
            RoleRepository = new RoleRepository(_academy);
            UserRolesRepository = new UserRolesRepository(_academy);
            UserRepository = new UserRepository(_academy);
            UniversityProfessorRepository = new UniversityProfessorRepository(_academy);
            UniversityStudentRepository = new UniversityStudentRepository(_academy);
            LogoutRepository = new LogoutRepository(_academy);
        }

        public IUniversityRepository UniversityRepository { get; private set; }

        public ICourseRepository CourseRepository { get; private set; }

        public IStudentRepository StudentRepository { get; private set; }

        public IProfessorRepository ProfessorRepository { get; private set; }

        public IProfessorRelationsRepository ProfessorRelationsRepository { get; private set; }

        public IStudentRelationsRepository StudentRelationsRepository { get; private set; }

        public IAccountRepository AccountRepository { get; private set; }

        public IUserRepository UserRepository { get; private set; }

        public IRoleRepository RoleRepository { get; private set; }

        public IUserRolesRepository UserRolesRepository { get; private set; }

        public ISemesterRepository SemesterRepository { get; private set; }

        public IUniversityProfessorRepository UniversityProfessorRepository { get; private set; }

        public IUniversityStudentRepository UniversityStudentRepository { get; private set; }

        public ILogoutRepository LogoutRepository { get; private set; }

        public int Complete()
        {
            return _academy.SaveChanges();
        }

        public void Dispose()
        {
            _academy.Dispose();
        }
    }
}
