using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            var username = "admin@email.com";
            AppUser admin = new()
            {
                Id = "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                UserName = username,
                Email = username,
                NormalizedEmail = username.ToUpper(),
                NormalizedUserName = username.ToUpper()
            };

            PasswordHasher<AppUser> passwordHasher = new();
            admin.PasswordHash = passwordHasher.HashPassword(admin, "mig00M!G");

            builder.HasData(admin);
        }
    }
}
