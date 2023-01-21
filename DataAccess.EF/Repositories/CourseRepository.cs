using Domain.Entities;
using Message.Commands;
using Message.ExtensionMethods;

namespace Repository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public string AreCoursesInUniversity(List<Guid> coursesId, Guid universityId)
        {
            var courses = _academy.Courses.Where(c => c.UniversityId != universityId && coursesId.Any(ci => ci == c.Id));
            return string.Join(",", courses.Select(c => c.Name));
        }

        public bool CheckCourseExistence(Guid courseId)
        {
            return _academy.Courses.Any(c => c.Id == courseId);
        }

        public bool IsCourseInUniversity(Guid courseId, Guid universityId)
        {
            return _academy.Courses.Any(c => c.UniversityId == universityId && c.Id == courseId);
        }


        public bool CheckListCourseExistence(List<Guid> ids)
        {
            return _academy.Courses.Any(c => ids.Any(i => i == c.Id));
        }

        public Course AddCourse(AddCourseCommand command, Guid universityId)
        {
            Course course = new()
            {
                Name = command.Name,
                Unit = command.Unit,
                UniversityId = universityId
            };
            return course;
        }

        public IEnumerable<Course> GetListCourse(string search, Guid universityId)
        {
            return _academy.Courses
                .Where(c => c.UniversityId == universityId && c.Name.Contains(search));
        }

        public IEnumerable<Course> GetListCourseByUniversityId(Guid universityId)
        {
            return _academy.Courses.Where(c => c.UniversityId == universityId);
        }

        public void RemoveListCourse(IEnumerable<Course> courses, Guid userId)
        {
            if (courses != null)
                foreach (var course in courses)
                {
                    course.IsActive = false;
                    course.ModifierId = userId;
                    course.ModificationDate = DateTime.Now;
                }
        }

        public void RemoveCourse(Course course, Guid userId)
        {
            course.IsActive = false;
            course.ModifierId = userId;
            course.ModificationDate = DateTime.Now;
        }
    }
}