namespace Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IUniversityRepository University { get; }
        ICourseRepository Course { get; }
        IStudentRepository Student { get; }
        IProfessorRepository Professor { get; }
        IReportRepository Report { get; }
        ICourseUniversityRepository CourseUniversity { get; }
        ICourseProfessorRepository CourseProfessor { get; }
        ICourseStudentRepository CourseStudent { get; }
        IProfessorStudentRepository ProfessorStudent { get; }
        int Complete();
    }
}
