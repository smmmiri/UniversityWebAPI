namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime Birthday { get; set; }
        public string StudentNumber { get; set; }
    }
}
