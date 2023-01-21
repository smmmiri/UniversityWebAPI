namespace Domain.Entities
{
    public class University : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public uint EstablishedYear { get; set; }
        public decimal Budget { get; set; }
    }
}
