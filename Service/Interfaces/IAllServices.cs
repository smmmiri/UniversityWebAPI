namespace Service.Interfaces
{
    public interface IAllServices
    {
        IUniversityService UniversityService { get; }
        ISemesterService SemesterService { get; }
        ICourseService CourseService { get; }
        IStudentService StudentService { get; }
        IProfessorService ProfessorService { get; }
        IAccountService AccountService { get; }
        IUserRoleService UserRoleService { get; }
        IUserService UserService { get; }
        IRoleService RoleService { get; }
    }
}
