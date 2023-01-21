using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FluentApiCourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> modelBuilder)
        {
            modelBuilder
                .HasQueryFilter(c => c.IsActive);
            modelBuilder
                .Property(c => c.Name)
                .IsRequired();
            modelBuilder
                .Property(c => c.Unit)
                .IsRequired();
            modelBuilder
                .Property(c => c.UniversityId)
                .IsRequired();
            modelBuilder
                .Property(c => c.Id)
                .IsRequired();
            modelBuilder
                .Property(c => c.CreatorId)
                .IsRequired();
            modelBuilder
                .Property(c => c.CreationDate)
                .IsRequired();
            modelBuilder
                .Property(c => c.ModifierId)
                .IsRequired();
            modelBuilder
                .Property(c => c.ModificationDate)
                .IsRequired();
        }
    }
}
