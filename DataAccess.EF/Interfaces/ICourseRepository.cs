using Domain.Entities;
using Message.Commands;

namespace Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        bool CheckListCourseExistence(List<Guid> ids);

        bool CheckCourseExistence(Guid courseId);

        string AreCoursesInUniversity(List<Guid> coursesId, Guid universityId);

        bool IsCourseInUniversity(Guid courseId, Guid universityId);

        Course AddCourse(AddCourseCommand command, Guid universityId);

        IEnumerable<Course> GetListCourse(string search, Guid universityId);
        
        IEnumerable<Course> GetListCourseByUniversityId(Guid universityId);

        void RemoveListCourse(IEnumerable<Course> courses, Guid userId);

        void RemoveCourse(Course course, Guid userId);
    }
}
