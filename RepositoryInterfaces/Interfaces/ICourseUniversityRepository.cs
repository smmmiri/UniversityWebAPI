using ApplicationCore.Entities;

namespace Repository
{
    public interface ICourseUniversityRepository : IGenericRepository<CourseUniversity>
    {
        IEnumerable<CourseUniversity>? GetUniversities(int id);
        IEnumerable<CourseUniversity>? GetCourses(int id);
        void RemoveRangeCourseUniversity(IEnumerable<CourseUniversity>? courseUniversities);
        CourseUniversity AddCourseUniversity(int courseId, int universityId);
    }
}
