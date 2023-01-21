namespace Message.DTOs
{
    public class OnlyStudentDTO
    {
        public Guid StudentId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string StudentNumber { get; set; }
    }
}
