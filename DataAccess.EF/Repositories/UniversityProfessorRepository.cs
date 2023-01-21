using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UniversityProfessorRepository : GenericRepository<UniversityProfessor>, 
        IUniversityProfessorRepository
    {
        public UniversityProfessorRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool IsProfessorInUniversity(Guid professorId, Guid universityId)
        {
            return _academy.UniversityProfessors
                .Any(up => up.ProfessorId == professorId && up.UniversityId == universityId);
        }

        public UniversityProfessor AddUniversityProfessor(Guid professorId, Guid universityId)
        {
            UniversityProfessor universityProfessor = new()
            {
                Id = Guid.NewGuid(),
                ProfessorId = professorId,
                UniversityId = universityId
            };
            return universityProfessor;
        }

        public IEnumerable<UniversityProfessor> GetListUniversityProfessor(Guid professorId)
        {
            return _academy.UniversityProfessors.Where(up => up.ProfessorId == professorId);
        }

        public void DeleteListUniversityProfessor(IEnumerable<UniversityProfessor> universityProfessors)
        {
            _academy.UniversityProfessors.RemoveRange(universityProfessors);
        }
    }
}
