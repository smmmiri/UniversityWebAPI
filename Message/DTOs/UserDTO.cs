namespace Message.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid UniversityId { get; set; }
        public string UniversityName { get; set; }
    }
}
