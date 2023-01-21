using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(new IdentityUserRole<string>()
            {
                RoleId = "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                UserId = "92C9AD1E-6CE5-4CA0-A79A-919407EA4069"
            });
        }
    }
}
