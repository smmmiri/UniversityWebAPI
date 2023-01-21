using Domain.Entities;
using Message.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class StudentRelationsRepository : GenericRepository<StudentRelations>, IStudentRelationsRepository
    {
        public StudentRelationsRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public StudentRelations AddStudentRelations(Student student, ProfessorRelations professorRelation)
        {
            StudentRelations studentRelation = new()
            {
                Student = student,
                ProfessorRelations = professorRelation
            };
            return studentRelation;
        }

        public StudentRelations GetStudentScore(Guid studentId, Guid courseId, Guid semesterId, Guid universityId)
        {
            return _academy.StudentRelations
                .Include(sr => sr.Student)
                .Include(sr => sr.ProfessorRelations.Professor)
                .Include(sr => sr.ProfessorRelations.Course)
                .Include(sr => sr.ProfessorRelations.Semester)
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId && 
                sr.ProfessorRelations.Semester.Id == semesterId && sr.ProfessorRelations.Course.Id == courseId && 
                sr.Student.Id == studentId)
                .Single();
        }

        public IEnumerable<StudentRelations> GetListStudent(string search, Guid semesterId, Guid universityId)
        {
            var result = _academy.StudentRelations
                .Include(sr => sr.Student)
                .Include(sr => sr.ProfessorRelations.Professor)
                .Include(sr => sr.ProfessorRelations.Course)
                .Include(sr => sr.ProfessorRelations.Semester)
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId);

            if (semesterId != Guid.Empty)
                result = result.Where(r => r.ProfessorRelations.Semester.Id == semesterId);

            return result
                .Where(r => (r.Student.FirstName + " " + r.Student.LastName).Contains(search) ||
                r.Student.NationalCode.Equals(search) || 
                r.Student.StudentNumber.Equals(search));
        }

        public IEnumerable<StudentRelations> GetListCourse(Guid studentId, Guid semesterId, Guid universityId)
        {
            var result = _academy.StudentRelations
                .Include(sr => sr.Student)
                .Include(sr => sr.ProfessorRelations.Course)
                .Include(sr => sr.ProfessorRelations.Professor)
                .Include(sr => sr.ProfessorRelations.Semester)
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId && sr.Student.Id == studentId);

            if (semesterId != Guid.Empty)
                result = result.Where(r => r.ProfessorRelations.Semester.Id == semesterId);

            return result;
        }

        public IEnumerable<StudentRelations> GetListStudentRelationsByCourseId(Guid courseId)
        {
            return _academy.StudentRelations.Where(sr => sr.ProfessorRelations.Course.Id == courseId).ToList();
        }

        public IEnumerable<StudentRelations> GetListProfessor(Guid studentId, Guid semesterId, Guid universityId)
        {
            var result = _academy.StudentRelations
                .Include(sr => sr.Student)
                .Include(sr => sr.ProfessorRelations.Professor)
                .Include(sr => sr.ProfessorRelations.Course)
                .Include(sr => sr.ProfessorRelations.Semester)
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId && sr.Student.Id == studentId);

            if (semesterId != Guid.Empty)
                result = result.Where(r => r.ProfessorRelations.Semester.Id == semesterId);

            return result;
        }

        public IEnumerable<StudentRelations> GetListStudentRelationsByStudentId(Guid studentId)
        {
            return _academy.StudentRelations.Where(sr => sr.Student.Id == studentId).ToList();
        }

        public StudentRelations GetStudentRelations(Guid studentId, Guid courseId, Guid semesterId, Guid universityId)
        {
            return _academy.StudentRelations
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId && 
                sr.ProfessorRelations.Course.Id == courseId && sr.Student.Id == studentId && 
                sr.ProfessorRelations.Semester.Id == semesterId)
                .Single();
        }

        public void DeleteListStudentRelations(IEnumerable<StudentRelations> studentRelations)
        {
            _academy.StudentRelations.RemoveRange(studentRelations);
        }

        public StudentRelations GetStudentRelation(Guid studentId, Guid professorRelationId)
        {
            return _academy.StudentRelations
                .Where(sr => sr.Student.Id == studentId && sr.ProfessorRelations.Id == professorRelationId)
                .SingleOrDefault();
        }

        public IEnumerable<StudentRelations> GetListStudentByProfessorId(Guid professorId, Guid semesterId, 
            Guid universityId)
        {
            var result = _academy.StudentRelations
                .Include(sr => sr.Student)
                .Include(sr => sr.ProfessorRelations.Professor)
                .Include(sr => sr.ProfessorRelations.Course)
                .Include(sr => sr.ProfessorRelations.Semester)
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId && 
                sr.ProfessorRelations.Professor.Id == professorId);

            if (semesterId != Guid.Empty)
                result = result.Where(r => r.ProfessorRelations.Semester.Id == semesterId);

            return result;
        }

        public IEnumerable<StudentRelations> GetListStudentByProfessorRelationsId(Guid professorRelationsId, 
            Guid semesterId, Guid universityId)
        {
            var result = _academy.StudentRelations
                .Include(sr => sr.Student)
                .Include(sr => sr.ProfessorRelations.Professor)
                .Include(sr => sr.ProfessorRelations.Semester)
                .Include(sr => sr.ProfessorRelations.Course)
                .Where(sr => sr.ProfessorRelations.Course.UniversityId == universityId && 
                sr.ProfessorRelations.Id == professorRelationsId);

            if (semesterId != Guid.Empty)
                result = result.Where(r => r.ProfessorRelations.Semester.Id == semesterId);

            return result;
        }

        public IEnumerable<Student> GetListStudents(IEnumerable<Course> courses)
        {
            return courses
                .SelectMany(c => _academy.StudentRelations.Where(sr => c == sr.ProfessorRelations.Course))
                .Select(sr => sr.Student);
        }

        public IEnumerable<StudentRelations> GetListStudentRelationsBySemesterId(Guid semesterId)
        {
            return _academy.StudentRelations.Where(sr => sr.ProfessorRelations.Semester.Id == semesterId);
        }

        public IEnumerable<StudentRelations> GetListStudentRelation(Guid studentId)
        {
            return _academy.StudentRelations.Where(sr => sr.Student.Id == studentId);
        }
    }
}
