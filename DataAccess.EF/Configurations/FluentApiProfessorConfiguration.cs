using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FluentApiProfessorConfiguration : IEntityTypeConfiguration<Professor>
    {
        public void Configure(EntityTypeBuilder<Professor> modelBuilder)
        {
            modelBuilder
                .HasQueryFilter(p => p.IsActive);
            modelBuilder
                .Property(p => p.FirstName)
                .IsRequired();
            modelBuilder
                .Property(p => p.LastName)
                .IsRequired();
            modelBuilder
                .Property(p => p.Birthday)
                .IsRequired();
            modelBuilder
                .Property(p => p.NationalCode)
                .IsRequired();
            modelBuilder
                .Property(p => p.Id)
                .IsRequired();
            modelBuilder
                .Property(p => p.CreatorId)
                .IsRequired();
            modelBuilder
                .Property(p => p.CreationDate)
                .IsRequired();
            modelBuilder
                .Property(p => p.ModifierId)
                .IsRequired();
            modelBuilder
                .Property(p => p.ModificationDate)
                .IsRequired();
        }
    }
}