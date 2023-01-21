using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface ICourseService
    {
        Task AddCourse(AddCourseCommand course, Guid userId, Guid universityId);

        Task AddScore(AddScoreCommand score, Guid userId, Guid universityId);
        
        Task<GetReturnDTO<OnlyCourseDTO>> GetListCourse(int pageNumber, int pageSize, string search, Guid universityId);

        Task<GetReturnDTO<CourseDTO>> GetListCourse
            (int pageNumber, int pageSize, string search, Guid semesterId, Guid universityId);

        Task<GetReturnDTO<CourseWithStudentDTO>> GetListCourseOfStudent
            (int pageNumber, int pageSize, Guid studentId, Guid semesterId, Guid universityId);

        Task<GetReturnDTO<CourseDTO>> GetListCourseOfProfessor
            (int pageNumber, int pageSize, Guid professorId, Guid semesterId, Guid universityId);
        
        Task UpdateCourse(UpdateCourseCommand course, Guid userId, Guid universityId);

        Task UpdateScore(UpdateScoreCommand score, Guid userId, Guid universityId);

        Task RemoveCourse(Guid courseId, Guid userId, Guid universityId);
    }
}
