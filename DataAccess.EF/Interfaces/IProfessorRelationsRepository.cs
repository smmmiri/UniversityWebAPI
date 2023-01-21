using Domain.Entities;

namespace Repository
{
    public interface IProfessorRelationsRepository : IGenericRepository<ProfessorRelations>
    {
        bool IsProfessorRelationsInUniversity(Guid professorRelationsId, Guid universityId);

        bool CheckProfessorRelationsExistence(Guid professorRelationsId);

        ProfessorRelations AddProfessorRelations(Semester semester, Course course, Professor professor, Guid userId, 
            decimal salary);

        ProfessorRelations AddProfessorRelations(Semester semester, Course course, Professor professor, decimal salary, 
            Guid userId);

        ProfessorRelations AddSalaryForProfessor(Semester semester, Course course, Professor professor, decimal salary, 
            Guid userId);

        IEnumerable<ProfessorRelations> GetListProfessor(string search, Guid semesterId, Guid universityId);

        ProfessorRelations GetProfessorRelations(Guid professorId, Guid courseId, Guid semesterId, Guid universityId);

        IEnumerable<Professor> GetListProfessor(IEnumerable<Course> courses);

        IEnumerable<ProfessorRelations> GetListCourse(string search, Guid semesterId, Guid universityId);

        IEnumerable<ProfessorRelations> GetListCourse(Guid semesterId, Guid professorId, Guid universityId);

        IEnumerable<ProfessorRelations> GetListProfessorRelations(Guid semesterId, Guid universityId);

        IEnumerable<ProfessorRelations> GetListProfessorRelationsByProfessorId(Guid professorId);

        IEnumerable<ProfessorRelations> GetListProfessorRelationsByCourseId(Guid courseId);

        IEnumerable<ProfessorRelations> GetListProfessorRelationsBySemesterId(Guid semesterId);

        void DeleteListProfessorRelations(IEnumerable<ProfessorRelations> professorRelations);
    }
}
