using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Repository.Configurations;

namespace Repository
{
    public class AcademyDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<ProfessorRelations> ProfessorRelations { get; set; }
        public DbSet<StudentRelations> StudentRelations { get; set; }
        public DbSet<UniversityProfessor> UniversityProfessors { get; set; }
        public DbSet<UniversityStudent> UniversityStudents { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<ExpiredToken> ExpiredTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Main"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // set configuration of roles
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            // seed admin user
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            // add admin role to admin user
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            // fluent api
            FluentApis.ConfigureFluentApis(modelBuilder);

            // Set all delete constraints to NO ACTION
            foreach (var relation in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relation.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }
    }
}
