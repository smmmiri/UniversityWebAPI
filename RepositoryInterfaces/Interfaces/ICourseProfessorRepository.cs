using ApplicationCore.Entities;

namespace Repository
{
    public interface ICourseProfessorRepository : IGenericRepository<CourseProfessor>
    {
        IEnumerable<CourseProfessor>? GetCourses(int id);
        IEnumerable<CourseProfessor>? GetProfessors(int id);
        void RemoveRangeCourseProfessor(IEnumerable<CourseProfessor>? courseProfessors);
        CourseProfessor AddCourseProfessor(int courseId, int professorId);
    }
}
