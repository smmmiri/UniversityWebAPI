using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole()
                {
                    Id = "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );
        }
    }
}
