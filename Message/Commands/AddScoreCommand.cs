namespace Message.Commands
{
    public class AddScoreCommand
    {
        public Guid CourseId { get; set; }
        public double Score { get; set; }
        public Guid StudentId { get; set; }
        public Guid SemesterId { get; set; }
    }
}
