using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class UniversityStudentRepository :
        GenericRepository<UniversityStudent>, IUniversityStudentRepository
    {
        public UniversityStudentRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool IsStudentInUniversity(Guid studentId, Guid universityId)
        {
            return _academy.UniversityStudents.Any(us => us.StudentId == studentId && us.UniversityId == universityId);
        }

        public UniversityStudent AddUniversityStudent(Guid studentId, Guid universityId)
        {
            UniversityStudent universityStudent = new()
            {
                Id = Guid.NewGuid(),
                StudentId = studentId,
                UniversityId = universityId
            };
            return universityStudent;
        }

        public IEnumerable<UniversityStudent> GetListUniversityStudent(Guid studentId)
        {
            return _academy.UniversityStudents.Where(us => us.StudentId == studentId);
        }

        public void DeleteListUniversityStudent(IEnumerable<UniversityStudent> universityStudents)
        {
            _academy.UniversityStudents.RemoveRange(universityStudents);
        }
    }
}
