using Domain.Entities;

namespace Repository
{
    public interface IStudentRelationsRepository : IGenericRepository<StudentRelations>
    {
        StudentRelations AddStudentRelations(Student student, ProfessorRelations professorRelation);

        IEnumerable<StudentRelations> GetListCourse(Guid studentId, Guid semesterId, Guid universityId);

        IEnumerable<StudentRelations> GetListStudent(string search, Guid semesterId, Guid universityId);

        StudentRelations GetStudentRelation(Guid studentId, Guid professorRelationId);

        StudentRelations GetStudentRelations(Guid studentId, Guid courseId, Guid semesterId, Guid universityId);

        StudentRelations GetStudentScore(Guid studentId, Guid courseId, Guid semesterId, Guid universityId);

        IEnumerable<Student> GetListStudents(IEnumerable<Course> courses);

        IEnumerable<StudentRelations> GetListStudentByProfessorId(Guid professorId, Guid semesterId, Guid universityId);

        IEnumerable<StudentRelations> GetListStudentByProfessorRelationsId(Guid professorRelationsId, Guid semesterId, 
            Guid universityId);

        IEnumerable<StudentRelations> GetListProfessor(Guid studentId, Guid semesterId, Guid universityId);

        IEnumerable<StudentRelations> GetListStudentRelationsByCourseId(Guid courseId);

        IEnumerable<StudentRelations> GetListStudentRelationsBySemesterId(Guid semesterId);

        IEnumerable<StudentRelations> GetListStudentRelationsByStudentId(Guid studentId);

        void DeleteListStudentRelations(IEnumerable<StudentRelations> studentRelations);
    }
}
