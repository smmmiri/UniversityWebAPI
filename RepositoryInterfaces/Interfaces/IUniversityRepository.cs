using ApplicationCore.Entities;
using Service.Models;

namespace Repository
{
    public interface IUniversityRepository : IGenericRepository<University>
    {
        bool UniversityExistenceCheck(int id);
        University AddUniversity(UniversityPostModel universityInput);
    }
}
