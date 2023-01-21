namespace Message.Commands
{
    public class SearchAndSemesterCommand : PaginationCommand
    {
        public string Search { get; set; } = "";
        public Guid SemesterId { get; set; } = Guid.Empty;
    }
}
