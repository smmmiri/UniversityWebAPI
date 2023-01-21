using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Repository.Configurations
{
    public class FluentApiSemesterConfiguration : IEntityTypeConfiguration<Semester>
    {
        public void Configure(EntityTypeBuilder<Semester> modelBuilder)
        {
            modelBuilder
                .HasQueryFilter(s => s.IsActive);
            modelBuilder
                .Property(s => s.SemesterNumber)
                .IsRequired();
            modelBuilder
                .Property(s => s.SemesterType)
                .HasColumnType("nvarchar(24)")
                .HasConversion<string>()
                .IsRequired();
            modelBuilder
                .Property(s => s.SemesterYear)
                .IsRequired();
            modelBuilder
                .Property(s => s.UniversityId)
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
