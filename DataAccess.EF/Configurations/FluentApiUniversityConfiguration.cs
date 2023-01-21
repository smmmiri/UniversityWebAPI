using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FluentApiUniversityConfiguration : IEntityTypeConfiguration<University>
    {
        public void Configure(EntityTypeBuilder<University> modelBuilder)
        {
            modelBuilder
                .HasQueryFilter(u => u.IsActive);
            modelBuilder
                .Property(u => u.Name)
                .IsRequired();
            modelBuilder
                .Property(u => u.Address)
                .IsRequired();
            modelBuilder
                .Property(u => u.EstablishedYear)
                .IsRequired();
            modelBuilder
                .Property(u => u.Budget)
                .IsRequired()
                .HasColumnType("money");
            modelBuilder
                .Property(u => u.Id)
                .IsRequired();
            modelBuilder
                .Property(u => u.CreatorId)
                .IsRequired();
            modelBuilder
                .Property(u => u.CreationDate)
                .IsRequired();
            modelBuilder
                .Property(u => u.ModifierId)
                .IsRequired();
            modelBuilder
                .Property(u => u.ModificationDate)
                .IsRequired();
        }
    }
}
