namespace Message.DTOs
{
    public class ProfessorDTO
    {
        public Guid ProfessorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterNumber { get; set; }
    }
}
