using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppRole : IdentityRole
    {
        public AppRole()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            IsActive = true;
        }

        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
