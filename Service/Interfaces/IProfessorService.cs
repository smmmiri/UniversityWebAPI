using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface IProfessorService
    {
        Task AddOnlyProfessor(AddOnlyProfessorCommand command, Guid userId, Guid universityId);

        Task AddProfessor(AddProfessorCommand command, Guid userId, Guid universityId);

        Task AddProfessorToCourse(AddProfessorToCourseCommand command, Guid userId, Guid universityId);

        Task AddSalaryForProfessor(AddSalaryForProfessorCommand command, Guid universityId, Guid userId);

        Task<GetReturnDTO<OnlyProfessorDTO>> GetListProfessor(int pageNumber, int pageSize, string search, 
            Guid universityId);

        Task<GetReturnDTO<ProfessorRelationsDTO>> GetListProfessor(int pageNumber, int pageSize, string search, 
            Guid semesterId, Guid universityId);

        Task<GetReturnDTO<ProfessorDTO>> GetListProfessorOfCourse(int pageNumber, int pageSize, Guid courseId, 
            Guid semesterId, Guid universityId);

        Task<GetReturnDTO<ProfessorWithStudentDTO>> GetListProfessorOfStudent(int pageNumber, int pageSize, Guid studentId, 
            Guid semesterId, Guid universityId);

        Task UpdateProfessor(UpdateProfessorCommand professor, Guid userId, Guid universityId);

        Task RemoveProfessor(Guid professorId, Guid userId, Guid universityId);

        Task DeleteProfessorFromCourse(DeleteProfessorFromCourseCommand command, Guid universityId);
    }
}
