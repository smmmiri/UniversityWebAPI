namespace Message.Commands
{
    public class AddSalaryForProfessorCommand
    {
        public Guid CourseId { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid SemesterId { get; set; }
        public decimal Salary { get; set; }
    }
}
