namespace Domain.Entities
{
    public class UniversityStudent
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public Guid StudentId { get; set; }
    }
}
