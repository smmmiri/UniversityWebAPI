using Microsoft.EntityFrameworkCore;
using Repository.Configurations;

namespace Repository
{
    public static class FluentApis
    {
        public static void ConfigureFluentApis(ModelBuilder modelBuilder)
        {
            // fluent api course
            modelBuilder.ApplyConfiguration(new FluentApiCourseConfiguration());
            // fluent api professor
            modelBuilder.ApplyConfiguration(new FluentApiProfessorConfiguration());
            // fluent api professorRelations
            modelBuilder.ApplyConfiguration(new FluentApiProfessorRelationsConfiguration());
            // fluent api student
            modelBuilder.ApplyConfiguration(new FluentApiStudentConfiguration());
            // fluent api university
            modelBuilder.ApplyConfiguration(new FluentApiUniversityConfiguration());
            // fluent api appuser
            modelBuilder.ApplyConfiguration(new FluentApiAppUserConfiguration());
            // fluent api approle
            modelBuilder.ApplyConfiguration(new FluentApiAppRoleConfiguration());
            // fluent api semester
            modelBuilder.ApplyConfiguration(new FluentApiSemesterConfiguration());
        }
    }
}
