using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IUniversityStudentRepository : IGenericRepository<UniversityStudent>
    {
        bool IsStudentInUniversity(Guid studentId, Guid universityId);

        UniversityStudent AddUniversityStudent(Guid studentId, Guid universityId);

        IEnumerable<UniversityStudent> GetListUniversityStudent(Guid studentId);

        void DeleteListUniversityStudent(IEnumerable<UniversityStudent> universityStudents);
    }
}
