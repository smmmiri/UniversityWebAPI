namespace Domain.Entities
{
    public class Log
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public Guid UserId { get; set; }
        public string StackTrace { get; set; }
        public string Exception { get; set; }
        public string Logger { get; set; }
        public string Url { get; set; }
    }
}
