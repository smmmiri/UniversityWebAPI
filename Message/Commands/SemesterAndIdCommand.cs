namespace Message.Commands
{
    public class SemesterAndIdCommand : PaginationCommand
    {
        public Guid SemesterId { get; set; } = Guid.Empty;
        public Guid Id { get; set; }
    }
}
