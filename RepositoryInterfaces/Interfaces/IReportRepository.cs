using ApplicationCore.DTOs;

namespace Repository
{
    public interface IReportRepository : IGenericRepository<object>
    {
        IEnumerable<StudentDTO> GetStudentsOfProfessor(int professorId);
        IEnumerable<StudentDTO> GetStudentsOfCourse(int courseId);
        IEnumerable<object> GetStudentsGradeOfUniversity(int universityId);
        object GetComplete();
    }
}
