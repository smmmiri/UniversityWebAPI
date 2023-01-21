namespace Message.Commands
{
    public class AddProfessorToCourseCommand
    {
        public Guid CourseId { get; set; }
        public Guid ProfessorId { get; set; }
        public Guid SemesterId { get; set; }
        public decimal Salary { get; set; }
    }
}
