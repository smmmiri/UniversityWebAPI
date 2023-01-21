namespace Message.Commands
{
    public class AddStudentToCourseCommand
    {
        public Guid StudentId { get; set; }
        public Guid ProfessorRelationId { get; set; }
    }
}
