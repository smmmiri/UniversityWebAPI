using Message.Enums;

namespace Message.Commands
{
    public class AddSemesterCommand
    {
        public string SemesterNumber { get; set; }
        public SemesterType SemesterType { get; set; }
        public DateTime SemesterYear { get; set; }
    }
}
