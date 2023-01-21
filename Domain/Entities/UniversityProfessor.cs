namespace Domain.Entities
{
    public class UniversityProfessor
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public Guid ProfessorId { get; set; }
    }
}
