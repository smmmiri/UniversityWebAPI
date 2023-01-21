using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class FluentApiProfessorRelationsConfiguration : IEntityTypeConfiguration<ProfessorRelations>
    {
        public void Configure(EntityTypeBuilder<ProfessorRelations> modelBuilder)
        {
            modelBuilder
                .Property(p => p.Id)
                .IsRequired();
            modelBuilder
                .Property(p => p.Salary)
                .HasColumnType("money")
                .IsRequired();
            modelBuilder
                .Property(p => p.CreatorId)
                .IsRequired();
            modelBuilder
                .Property(p => p.CreationDate)
                .IsRequired();
        }
    }
}