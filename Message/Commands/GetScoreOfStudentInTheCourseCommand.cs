namespace Message.Commands
{
    public class GetScoreOfStudentInTheCourseCommand
    {
        public Guid SemesterId { get; set; } = Guid.Empty;
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
    }
}
