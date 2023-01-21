using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Id = Guid.NewGuid().ToString();
            CreationDate = DateTime.Now;
            IsActive = true;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? UniversityId { get; set; }

        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
