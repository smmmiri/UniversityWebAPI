using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface ISemesterService
    {
        Task AddSemester(AddSemesterCommand command, Guid userId, Guid universityId);

        Task<GetReturnDTO<SemesterDTO>> GetListSemesters(int pageNumber, int pageSize, string search, Guid universityId);

        Task UpdateSemester(UpdateSemesterCommand command, Guid userId, Guid universityId);

        Task RemoveSemester(Guid semesterId, Guid userId, Guid universityId);
    }
}
