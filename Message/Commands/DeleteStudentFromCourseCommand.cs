namespace Message.Commands
{
    public class DeleteStudentFromCourseCommand
    {
        public Guid StudentId { get; set; }
        public Guid ProfessorRelationId { get; set; }
    }
}
