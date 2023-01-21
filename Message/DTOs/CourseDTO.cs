namespace Message.DTOs
{
    public class CourseDTO
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
        public Guid ProfessorId { get; set; }
        public string ProfessorFirstName { get; set; }
        public string ProfessorLastName { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterNumber { get; set; }
    }
}
