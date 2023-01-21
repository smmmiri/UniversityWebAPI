namespace Message.DTOs
{
    public class UniversityDTO
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public uint EstablishedYear { get; set; }
        public decimal Budget { get; set; }
    }
}
