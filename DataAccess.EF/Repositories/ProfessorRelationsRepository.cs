using Domain.Entities;
using Message.ExtensionMethods;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repositories
{
    public class ProfessorRelationsRepository : GenericRepository<ProfessorRelations>,
        IProfessorRelationsRepository
    {
        public ProfessorRelationsRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool IsProfessorRelationsInUniversity(Guid professorRelationsId, Guid universityId)
        {
            return _academy.ProfessorRelations.Any(pr => pr.Semester.UniversityId == universityId);
        }

        public bool CheckProfessorRelationsExistence(Guid professorRelationsId)
        {
            return _academy.ProfessorRelations.Any(pr => pr.Id == professorRelationsId);
        }

        public ProfessorRelations AddProfessorRelations(Semester semester, Course course, Professor professor, Guid userId, 
            decimal salary)
        {
            ProfessorRelations professorRelation = new()
            {
                Semester = semester,
                Course = course,
                Professor = professor,
                Salary = salary,
                CreatorId = userId,
                CreationDate = DateTime.Now
            };
            return professorRelation;
        }

        public ProfessorRelations AddProfessorRelations(Semester semester, Course course, Professor professor, 
            decimal salary, Guid userId)
        {
            ProfessorRelations professorRelation = new()
            {
                Semester = semester,
                Course = course,
                Professor = professor,
                Salary = salary,
                CreatorId = userId,
                CreationDate = DateTime.Now
            };
            return professorRelation;
        }

        public ProfessorRelations AddSalaryForProfessor(Semester semester, Course course, Professor professor, 
            decimal salary, Guid userId)
        {
            ProfessorRelations professorRelation = new()
            {
                Semester = semester,
                Course = course,
                Professor = professor,
                Salary = salary,
                CreatorId = userId,
                CreationDate = DateTime.Now
            };
            return professorRelation;
        }

        public IEnumerable<ProfessorRelations> GetListProfessor(string search, Guid semesterId, Guid universityId)
        {
            var professorRelations = _academy.ProfessorRelations
                .Include(pr => pr.Professor)
                .Include(pr => pr.Course)
                .Include(pr => pr.Semester)
                .Where(pr => pr.Course.UniversityId == universityId)
                .ToList();

            professorRelations.RemoveAll(item => item.Professor == null);

            if (semesterId != Guid.Empty)
                professorRelations = professorRelations.Where(p => p.Semester.Id == semesterId).ToList();

            return professorRelations
                .Where(p => (p.Professor.FirstName + " " + p.Professor.LastName).Contains(search) ||
                p.Professor.NationalCode.Equals(search));
        }

        public IEnumerable<Professor> GetListProfessor(IEnumerable<Course> courses)
        {
            return courses
                .SelectMany(c => _academy.ProfessorRelations.Where(pr => pr.Course == c))
                .Select(c => c.Professor);
        }

        public IEnumerable<ProfessorRelations> GetListCourse(Guid semesterId, Guid professorId, Guid universityId)
        {
            var result = _academy.ProfessorRelations
                .Include(pr => pr.Professor)
                .Include(pr => pr.Course)
                .Include(pr => pr.Semester)
                .Where(pr => pr.Course.UniversityId == universityId && pr.Professor.Id == professorId);

            if (semesterId != Guid.Empty)
                return result.Where(r => r.Semester.Id == semesterId);

            return result;
        }

        public IEnumerable<ProfessorRelations> GetListProfessorRelations(Guid semesterId, Guid universityId)
        {
            var result = _academy.ProfessorRelations
                .Include(pr => pr.Semester)
                .Include(pr => pr.Course)
                .Include(pr => pr.Professor)
                .Where(pr => pr.Course.UniversityId == universityId);

            if (semesterId != Guid.Empty)
                return result.Where(r => r.Semester.Id == semesterId);

            return result;
        }

        public IEnumerable<ProfessorRelations> GetListProfessorRelationsByCourseId(Guid courseId)
        {
            return _academy.ProfessorRelations.Where(pr => pr.Course.Id == courseId).ToList();
        }

        public IEnumerable<ProfessorRelations> GetListProfessorRelationsByProfessorId(Guid professorId)
        {
            return _academy.ProfessorRelations.Where(pr => pr.Professor.Id == professorId).ToList();
        }

        public ProfessorRelations GetProfessorRelations(Guid professorId, Guid courseId, Guid semesterId, 
            Guid universityId)
        {
            return _academy.ProfessorRelations
                .Where(pr => pr.Course.UniversityId == universityId && pr.Semester.Id == semesterId &&
                pr.Course.Id == courseId && pr.Professor.Id == professorId)
                .Single();
        }

        public IEnumerable<ProfessorRelations> GetListProfessorRelationsBySemesterId(Guid semesterId)
        {
            return _academy.ProfessorRelations.Where(pr => pr.Semester.Id == semesterId);
        }

        public IEnumerable<ProfessorRelations> GetListCourse(string search, Guid semesterId, Guid universityId)
        {
            var result = _academy.ProfessorRelations
                .Include(pr => pr.Professor)
                .Include(pr => pr.Course)
                .Include(pr => pr.Semester)
                .Where(pr => pr.Course.UniversityId == universityId && pr.Course.Name.Contains(search));

            if (semesterId != Guid.Empty)
                return result.Where(r => r.Semester.Id == semesterId);

            return result;
        }

        public void DeleteListProfessorRelations(IEnumerable<ProfessorRelations> professorRelations)
        {
            _academy.ProfessorRelations.RemoveRange(professorRelations);
        }
    }
}
