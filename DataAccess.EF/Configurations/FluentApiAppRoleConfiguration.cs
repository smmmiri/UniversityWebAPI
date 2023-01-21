using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FluentApiAppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> modelBuilder)
        {
            modelBuilder
                .HasQueryFilter(r => r.IsActive);
        }
    }
}
