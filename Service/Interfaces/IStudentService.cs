using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface IStudentService
    {
        Task AddOnlyStudent(AddOnlyStudentCommand command, Guid userId, Guid universityId);

        Task AddStudent(AddStudentCommand student, Guid userId, Guid universityId);

        Task AddStudentToCourse(AddStudentToCourseCommand command, Guid universityId);

        Task<GetReturnDTO<OnlyStudentDTO>> GetListStudent(int pageNumber, int pageSize, string search, Guid universityId);

        Task<GetReturnDTO<StudentDTO>> GetListStudent(int pageNumber, int pageSize, string search, Guid semesterId, 
            Guid universityId);

        Task<GetReturnDTO<StudentDTO>> GetListStudentOfCourse(int pageNumber, int pageSize, Guid professorRelationsId, 
            Guid semesterId, Guid universityId);

        Task<GetReturnDTO<StudentDTO>> GetListStudentOfProfessor(int pageNumber, int pageSize, Guid professorId, 
            Guid semesterId, Guid universityId);

        Task<StudentWithScoreDTO> GetScoreOfStudentInTheCourse(Guid studentId, Guid courseId, Guid semesterId, 
            Guid universityId);

        Task UpdateStudent(UpdateStudentCommand student, Guid userId, Guid universityId);

        Task RemoveStudent(Guid studentId, Guid userId, Guid universityId);

        Task DeleteStudentFromCourse(DeleteStudentFromCourseCommand command, Guid universityId);
    }
}
