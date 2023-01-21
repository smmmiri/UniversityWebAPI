using Domain.Entities;
using Message.Commands;

namespace Repository
{
    public class ProfessorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public Guid CheckProfessorNationalCodeExistence(string nationalCode)
        {
            var id = Guid.Empty;

            if (_academy.Professors.Any(p => p.NationalCode == nationalCode))
                id = _academy.Professors.Where(p => p.NationalCode == nationalCode).Select(p => p.Id).Single();

            return id;
        }

        public bool CheckProfessorExistence(Guid professorId)
        {
            return _academy.Professors.Any(p => p.Id == professorId);
        }

        public bool CheckProfessorNationalCodeRepetivity(string nationalCode, Guid professorId)
        {
            return _academy.Professors.Any(p => p.Id != professorId && p.NationalCode == nationalCode);
        }

        public Professor AddProfessor(AddOnlyProfessorCommand command)
        {
            Professor professor = new()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                NationalCode = command.NationalCode,
                Birthday = command.Birthday
            };
            return professor;
        }

        public IEnumerable<Professor> GetListProfessor(string search, Guid universityId)
        {
            return _academy.UniversityProfessors
                .Where(up => up.UniversityId == universityId)
                .Join(_academy.Professors,
                up => up.ProfessorId,
                p => p.Id,
                (up, p) => new Professor
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    Birthday = p.Birthday,
                    NationalCode = p.NationalCode,
                    IsActive = p.IsActive,
                    CreatorId = p.CreatorId,
                    CreationDate = p.CreationDate,
                    ModifierId = p.ModifierId,
                    ModificationDate = p.ModificationDate
                })
                .Where(p => (p.FirstName + " " + p.LastName).Contains(search) || p.NationalCode.Equals(search));
        }

        public void RemoveProfessor(Professor professor, Guid userId)
        {
            professor.IsActive = false;
            professor.ModifierId = userId;
            professor.ModificationDate = DateTime.Now;
        }

        public void RemoveProfessors(IEnumerable<Professor> professors, Guid userId)
        {
            if (professors != null)
                foreach (var professor in professors)
                {
                    professor.IsActive = false;
                    professor.ModifierId = userId;
                    professor.ModificationDate = DateTime.Now;
                }
        }
    }
}
