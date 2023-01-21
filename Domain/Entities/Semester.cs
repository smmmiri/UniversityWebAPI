using Message.Enums;

namespace Domain.Entities
{
    public class Semester : BaseEntity
    {
        public string SemesterNumber { get; set; }
        public SemesterType SemesterType { get; set; }
        public DateTime SemesterYear { get; set; }
        public Guid UniversityId { get; set; }
    }
}
