using Message.Commands;
using Message.DTOs;

namespace Service.Interfaces
{
    public interface IUniversityService
    {
        Task AddUniversity(AddUniversityCommand university, Guid userId);

        Task<GetReturnDTO<UniversityDTO>> GetListUniversityAsync(int pageNumber, int pageSize, string search);

        Task UpdateUniversityForUser(UpdateUniversityForUserCommand command, Guid userId, Guid universityId);

        Task UpdateUniversityForAdmin(UpdateUniversityForAdminCommand command, Guid userId);

        Task RemoveUniversity(Guid id, Guid userId);
    }
}
