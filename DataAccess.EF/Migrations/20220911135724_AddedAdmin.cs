using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00690f09-cee2-4048-aa4b-69171aeb7693");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76c0bb89-343f-4545-8097-dd8b5a675f57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8C107E3D-988D-4432-AEF3-B27354E62058", "f74415c5-27b7-4cc9-9058-d4b13f131d1d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9", "86b298cf-eaea-4f8f-8bf0-2d05d7114b41", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "92C9AD1E-6CE5-4CA0-A79A-919407EA4069", 0, "2e2dbd60-998f-404b-9f92-92f01a1ea28b", "admin@email.com", false, null, null, false, null, null, null, null, null, false, "a3301c2b-4c7c-48da-84e7-0a88fd8c676e", false, "admin@email.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9", "92C9AD1E-6CE5-4CA0-A79A-919407EA4069" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9", "92C9AD1E-6CE5-4CA0-A79A-919407EA4069" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00690f09-cee2-4048-aa4b-69171aeb7693", "be263fef-511a-4aa0-8b17-e3361437db89", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "76c0bb89-343f-4545-8097-dd8b5a675f57", "f2ca74de-a772-4f8f-95ac-81502abb4e3c", "User", "USER" });
        }
    }
}
