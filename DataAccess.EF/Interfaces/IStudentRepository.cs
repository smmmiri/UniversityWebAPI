using Domain.Entities;
using Message.Commands;

namespace Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Guid CheckStudentNationalCodeExistence(string nationalCode);

        Guid CheckStudentNumberExistence(string studentNumber);

        bool CheckStudentNationalCodeRepetivity(string nationalCode, Guid studentId);

        bool CheckStudentNumberRepetivity(string studentNumber, Guid studentId);

        bool CheckStudentExistence(Guid studentId);

        Student AddStudent(AddOnlyStudentCommand command);

        IEnumerable<Student> GetListStudent(string search, Guid universityId);

        void RemoveStudents(IEnumerable<Student> students, Guid userId);

        void RemoveStudent(Student student, Guid userId);
    }
}
