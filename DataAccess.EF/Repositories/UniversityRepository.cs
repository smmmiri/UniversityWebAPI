using Domain.Entities;
using Message;
using Message.Commands;
using Message.ExtensionMethods;

namespace Repository
{
    public class UniversityRepository : GenericRepository<University>, IUniversityRepository
    {
        public UniversityRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool CheckUniversityExistence(Guid universityId)
        {
            return _academy.Universities.Any(u => u.Id == universityId);
        }

        public University AddUniversity(AddUniversityCommand command)
        {
            University university = new()
            {
                Name = command.Name,
                Address = command.Address,
                EstablishedYear = command.EstablishedYear,
                Budget = command.Budget
            };
            return university;
        }

        public IEnumerable<University> GetListUniversity(string search)
        {
            return _academy.Universities.Where(u => u.Name.Contains(search));
        }

        public void RemoveUniversity(University university, Guid userId)
        {
            university.IsActive = false;
            university.ModifierId = userId;
            university.ModificationDate = DateTime.Now;
        }
    }
}
