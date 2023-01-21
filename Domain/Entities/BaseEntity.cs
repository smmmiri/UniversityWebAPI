namespace Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.Now;
            IsActive = true;
        }

        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
