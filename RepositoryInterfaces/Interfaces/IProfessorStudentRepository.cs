using ApplicationCore.Entities;

namespace Repository
{
    public interface IProfessorStudentRepository : IGenericRepository<ProfessorStudent>
    {
        IEnumerable<ProfessorStudent>? GetProfessors(int id);
        IEnumerable<ProfessorStudent>? GetStudents(int id);
        void RemoveRangeProfessorStudent(IEnumerable<ProfessorStudent>? professorStudents);
    }
}
