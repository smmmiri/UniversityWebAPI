using Message.Enums;

namespace Message.DTOs
{
    public class SemesterDTO
    {
        public Guid SemesterId { get; set; }
        public string SemesterNumber { get; set; }
        public string SemesterType { get; set; }
        public DateTime SememsterYear { get; set; }
        public Guid UniversityId { get; set; }
        public string UniversityName { get; set; }
    }
}
