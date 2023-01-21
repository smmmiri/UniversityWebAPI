using Domain.Entities;
using Message.Commands;
using Message.ExtensionMethods;

namespace Repository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public Guid CheckStudentNationalCodeExistence(string nationalCode)
        {
            var id = Guid.Empty;

            if (_academy.Students.Any(s => s.NationalCode == nationalCode))
                id = _academy.Students.Where(s => s.NationalCode == nationalCode).Select(s => s.Id).Single();

            return id;
        }

        public Guid CheckStudentNumberExistence(string studentNumber)
        {
            var id = Guid.Empty;

            if (_academy.Students.Any(s => s.StudentNumber == studentNumber))
                id = _academy.Students.Where(s => s.StudentNumber == studentNumber).Select(s => s.Id).Single();

            return id;
        }

        public bool CheckStudentNationalCodeRepetivity(string nationalCode, Guid studentId)
        {
            return _academy.Students.Any(s => s.Id != studentId && s.NationalCode == nationalCode);
        }

        public bool CheckStudentExistence(Guid studentId)
        {
            return _academy.Students.Any(s => s.Id == studentId);
        }

        public bool CheckStudentNumberRepetivity(string studentNumber, Guid studentId)
        {
            return _academy.Students.Any(s => s.Id != studentId && s.StudentNumber == studentNumber);
        }

        public Student AddStudent(AddOnlyStudentCommand command)
        {
            Student student = new()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                NationalCode = command.NationalCode,
                Birthday = command.Birthday,
                StudentNumber = command.StudentNumber
            };
            return student;
        }

        public IEnumerable<Student> GetListStudent(string search, Guid universityId)
        {
            return _academy.UniversityStudents
                .Where(us => us.UniversityId == universityId)
                .Join(_academy.Students,
                us => us.StudentId,
                s => s.Id,
                (us, s) => new Student
                {
                    Id = s.Id,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Birthday = s.Birthday,
                    StudentNumber = s.StudentNumber,
                    NationalCode = s.NationalCode,
                    IsActive = s.IsActive,
                    CreatorId = s.CreatorId,
                    CreationDate = s.CreationDate,
                    ModifierId = s.ModifierId,
                    ModificationDate = s.ModificationDate
                })
                .Where(p => (p.FirstName + " " + p.LastName).Contains(search) || 
                p.NationalCode.Equals(search) || 
                p.StudentNumber.Equals(search));
        }

        public void RemoveStudent(Student student, Guid userId)
        {
            student.IsActive = false;
            student.ModifierId = userId;
            student.ModificationDate = DateTime.Now;
        }

        public void RemoveStudents(IEnumerable<Student> students, Guid userId)
        {
            if (students != null)
                foreach (var student in students)
                {
                    student.IsActive = false;
                    student.ModifierId = userId;
                    student.ModificationDate = DateTime.Now;
                }
        }
    }
}
