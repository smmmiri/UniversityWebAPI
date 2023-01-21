using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Repository;
using Service.Interfaces;
using Service.Services;

namespace Service.ControllersServices
{
    public class AllServices : IAllServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AllServices> _logger;

        public AllServices(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IConfiguration configuration, ILogger<AllServices> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _logger = logger;
            UniversityService = new UniversityService(_unitOfWork);
            SemesterService = new SemesterService(_unitOfWork);
            CourseService = new CourseService(_unitOfWork);
            StudentService = new StudentService(_unitOfWork);
            ProfessorService = new ProfessorService(_unitOfWork);
            AccountService = new AccountService(_userManager, _signInManager, _configuration, _logger, _unitOfWork);
            UserRoleService = new UserRoleService(_unitOfWork);
            UserService = new UserService(_unitOfWork);
            RoleService = new RoleService(_unitOfWork);
        }
        public IUniversityService UniversityService { get; private set; }
        public ISemesterService SemesterService { get; private set; }
        public ICourseService CourseService { get; private set; }
        public IStudentService StudentService { get; private set; }
        public IProfessorService ProfessorService { get; private set; }
        public IAccountService AccountService { get; private set; }
        public IUserRoleService UserRoleService { get; private set; }
        public IUserService UserService { get; private set; }
        public IRoleService RoleService { get; private set; }
    }
}
