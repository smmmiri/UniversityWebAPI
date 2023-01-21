using ApplicationCore.Entities;
using Service.Models;

namespace Repository
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        bool UnitCheck(int input);
        bool CourseExistenceCheck(List<int> id);
        Course AddCourse(CoursePostModel coursePost);
    }
}
