namespace Message.DTOs
{
    public class ProfessorWithStudentDTO
    {
        public Guid ProfessorId { get; set; }
        public string ProfessorFirstName { get; set; }
        public string ProfessorLastName { get; set; }
        public string ProfessorNationalCode { get; set; }
        public DateTime ProfessorBirthday { get; set; }
        public int Age { get; set; }
        public decimal ProfessorSalary { get; set; }
        public Guid CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid SemesterId { get; set; }
        public string SemesterNumber { get; set; }
        public Guid StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
    }
}
