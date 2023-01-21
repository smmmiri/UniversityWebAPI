using ApplicationCore.Entities;
using Service.Models;

namespace Repository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        bool StudentSameNationalCheck(string nationalCode, int id);
        bool StudentDuplicateCheck(string nationalCode);
        bool StudentExistenceCheck(int id);
        bool AgeCheck(int input);
        bool NationalCheck(string input);
        Student AddStudent(StudentPostModel postModel);
    }
}
