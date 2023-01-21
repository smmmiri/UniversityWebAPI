using ApplicationCore.Entities;

namespace Repository
{
    public interface ICourseStudentRepository : IGenericRepository<CourseStudent>
    {
        IEnumerable<CourseStudent>? GetCourses(int id);
        IEnumerable<CourseStudent>? GetStudents(int id);
        CourseStudent? GetCourseStudents(int courseId, int studentId);
        void RemoveRangeCourseStudent(IEnumerable<CourseStudent>? courseStudents);
        bool ScoreCheck(double input);
        CourseStudent AddCourseStudent(int courseId, int studentId);
    }
}
