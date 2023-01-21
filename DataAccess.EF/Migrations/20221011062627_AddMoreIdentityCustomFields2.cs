using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddMoreIdentityCustomFields2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "c9db8628-4459-4e73-8438-028511919f59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "82fffa2a-8f0e-42c6-b8f4-e8bf8794e3f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270cfafa-2328-4130-bd2e-7dfb9bf3973c", "AQAAAAEAACcQAAAAEHGWujjZ/wZ2bnDp9tMRCFg9pZb+0sbPQng8sD/uNjMGtpqHCTr6TZHLb0jNWZjEHw==", "78d0315f-29b7-41c0-8314-f7d222c987dc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "cb2c3dae-f434-4ad3-ac63-e9b4a9eec01b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "0f7ea692-c49c-48ea-8b0f-a895e82f6788");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03e17125-340a-4ccd-a994-6732f667a308", "AQAAAAEAACcQAAAAEP9+uhqvCf+Owq6pZW4SSSzQevqw+f1Yi4NldtxNdfFzC7MVPQ1aL1daRVzCCX7gIw==", "e7aaffaa-e9f5-44c0-ae90-2a06ab2a13fc" });
        }
    }
}
