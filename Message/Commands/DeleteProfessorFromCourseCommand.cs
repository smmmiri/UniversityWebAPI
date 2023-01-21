namespace Message.Commands
{
    public class DeleteProfessorFromCourseCommand
    {
        public Guid ProfessorId { get; set; }
        public Guid CourseId { get; set; }
        public Guid SemesterId { get; set; }
    }
}
