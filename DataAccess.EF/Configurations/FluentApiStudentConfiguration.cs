using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FluentApiStudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> modelBuilder)
        {
            modelBuilder
                .HasQueryFilter(s => s.IsActive);
            modelBuilder
                .Property(s => s.FirstName)
                .IsRequired();
            modelBuilder
                .Property(s => s.LastName)
                .IsRequired();
            modelBuilder
                .Property(s => s.Birthday)
                .IsRequired();
            modelBuilder
                .Property(s => s.NationalCode)
                .IsRequired();
            modelBuilder
                .Property(s => s.StudentNumber)
                .IsRequired();
            modelBuilder
                .Property(s => s.Id)
                .IsRequired();
            modelBuilder
                .Property(s => s.CreatorId)
                .IsRequired();
            modelBuilder
                .Property(s => s.CreationDate)
                .IsRequired();
            modelBuilder
                .Property(s => s.ModifierId)
                .IsRequired();
            modelBuilder
                .Property(s => s.ModificationDate)
                .IsRequired();
        }
    }
}
