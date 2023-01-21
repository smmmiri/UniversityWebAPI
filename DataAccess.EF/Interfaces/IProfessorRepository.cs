using Domain.Entities;
using Message.Commands;

namespace Repository
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        bool CheckProfessorExistence(Guid professorId);

        Guid CheckProfessorNationalCodeExistence(string nationalCode);

        bool CheckProfessorNationalCodeRepetivity(string nationalCode, Guid professorId);

        Professor AddProfessor(AddOnlyProfessorCommand professorPost);

        IEnumerable<Professor> GetListProfessor(string search, Guid universityId);

        void RemoveProfessors(IEnumerable<Professor> professors, Guid userId);

        void RemoveProfessor(Professor professor, Guid userId);
    }
}
