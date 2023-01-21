using Domain.Entities;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
    {
        public SemesterRepository(AcademyDbContext academy) : base(academy)
        {
        }

        public bool IsSemesterInUniversity(Guid semesterId, Guid universityId)
        {
            return _academy.Semesters.Any(s => s.UniversityId == universityId && s.Id == semesterId);
        }

        public bool CheckSemesterExistence(Guid semesterId)
        {
            return _academy.Semesters.Any(s => s.Id == semesterId);
        }

        public bool CheckSemesterExistence(string semesterNumber)
        {
            return _academy.Semesters.Any(s => s.SemesterNumber == semesterNumber);
        }

        public Semester AddSemester(AddSemesterCommand command, Guid universityId)
        {
            Semester semester = new()
            {
                SemesterNumber = command.SemesterNumber,
                SemesterType = command.SemesterType,
                SemesterYear = command.SemesterYear,
                UniversityId = universityId
            };
            return semester;
        }

        public IEnumerable<SemesterDTO> GetListSemester(string search, Guid universityId)
        {
            return _academy.Semesters
                .Where(s => s.SemesterNumber.Contains(search) && s.UniversityId == universityId)
                .Join(_academy.Universities,
                semester => semester.UniversityId,
                university => university.Id,
                (semester, university) => new SemesterDTO
                {
                    SemesterId = semester.Id,
                    SemesterType = semester.SemesterType.GetDescription(),
                    SememsterYear = semester.SemesterYear,
                    SemesterNumber = semester.SemesterNumber,
                    UniversityId = university.Id,
                    UniversityName = university.Name
                });
        }

        public IEnumerable<Semester> GetListSemesterByUniversityId(Guid universityId)
        {
            return _academy.Semesters.Where(s => s.UniversityId == universityId).ToList();
        }

        public void RemoveSemesters(IEnumerable<Semester> semesters, Guid userId)
        {
            if (semesters != null)
                foreach (var semester in semesters)
                {
                    semester.IsActive = false;
                    semester.ModifierId = userId;
                    semester.ModificationDate = DateTime.Now;
                }
        }
    }
}
