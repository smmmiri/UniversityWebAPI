namespace Message.Commands
{
    public class UpdateCourseCommand
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public int Unit { get; set; }
    }
}