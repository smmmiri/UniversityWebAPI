using Domain.Entities;

namespace Repository.Interfaces
{
    public interface IUniversityProfessorRepository : IGenericRepository<UniversityProfessor>
    {
        bool IsProfessorInUniversity(Guid professorId, Guid universityId);

        UniversityProfessor AddUniversityProfessor(Guid professorId, Guid universityId);

        IEnumerable<UniversityProfessor> GetListUniversityProfessor(Guid professorId);

        void DeleteListUniversityProfessor(IEnumerable<UniversityProfessor> universityProfessors);
    }
}
