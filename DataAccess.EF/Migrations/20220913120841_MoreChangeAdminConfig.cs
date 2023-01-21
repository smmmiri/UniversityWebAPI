using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class MoreChangeAdminConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "5b96725c-e7b0-4c32-b7bb-6829043dda7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "7e1f36f2-f12b-42fd-8732-0dafc2820f95");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dce3da6-496e-41a6-a155-a957e5a77c9a", "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAEAACcQAAAAEEM2HKbHFoVO0egUDAyhDgyw5c4BKHwSRvjUmxB6UcRldz7wV8Lg9Ib9dIK0pvms0w==", "ac32d8b0-b764-4e67-ae1c-09830a85828d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "6cadcce3-401f-4e29-9364-c1300cfebfd4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "75ff449f-467e-440d-a0cb-2a92e211141d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bbb1ff06-3f66-4834-a541-ef670bb48f0e", null, null, "AQAAAAEAACcQAAAAEHfEvZZ+DGg9TBx5+ZbmWM3QIAYiHXBpoXdnGYFEKFs87Rizag7DmzobiLigetilDA==", "5ab9f38e-5e23-4322-b91e-2314da3fb76a" });
        }
    }
}
