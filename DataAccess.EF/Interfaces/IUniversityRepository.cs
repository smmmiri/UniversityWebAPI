using Domain.Entities;
using Message;
using Message.Commands;

namespace Repository
{
    public interface IUniversityRepository : IGenericRepository<University>
    {
        bool CheckUniversityExistence(Guid universityId);

        University AddUniversity(AddUniversityCommand universityInput);

        IEnumerable<University> GetListUniversity(string search);

        void RemoveUniversity(University university, Guid userId);
    }
}
