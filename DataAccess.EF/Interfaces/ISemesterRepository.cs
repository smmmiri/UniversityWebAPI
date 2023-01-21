using Domain.Entities;
using Message.Commands;
using Message.DTOs;

namespace Repository.Interfaces
{
    public interface ISemesterRepository : IGenericRepository<Semester>
    {
        bool IsSemesterInUniversity(Guid semesterId, Guid universityId);

        bool CheckSemesterExistence(Guid semesterId);

        bool CheckSemesterExistence(string semesterNumber);

        Semester AddSemester(AddSemesterCommand command, Guid universityId);
        
        IEnumerable<SemesterDTO> GetListSemester(string search, Guid universityId);

        IEnumerable<Semester> GetListSemesterByUniversityId(Guid universityId);

        void RemoveSemesters(IEnumerable<Semester> semesters, Guid userId);
    }
}
