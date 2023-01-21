namespace Message.DTOs
{
    public class OnlyProfessorDTO
    {
        public Guid ProfessorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
    }
}
