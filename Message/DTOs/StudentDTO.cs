namespace Message.DTOs
{
    public class StudentDTO
    {
        public Guid StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string StudentNumber { get; set; }
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public Guid ProfessorId { get; set; }
        public string ProfessorFirstName { get; set; }
        public string ProfessorLastName { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterNumber { get; set; }
    }
}
