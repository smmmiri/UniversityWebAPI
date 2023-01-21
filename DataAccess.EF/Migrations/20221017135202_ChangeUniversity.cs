using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeUniversity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Budget",
                table: "Universities",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "EstablishedYear",
                table: "Universities",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "bca744f4-58c8-40f9-87dc-accb04abcc72");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "4845b05f-3f00-45af-9b76-8303f504f940");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c90bb35-cf63-44f9-8c71-32808b73af79", "AQAAAAEAACcQAAAAELKAilJNBxK4KebneTrdO/9Qz75XkYGMu6nKp8G/ttX3LELab9OKfG/FaKQbq86adg==", "14c5fd09-51ac-45d3-ac09-f8d2e44958f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "EstablishedYear",
                table: "Universities");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "38652836-72f1-425a-9fe2-00c27023b857");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "c2837776-6454-4267-af72-4add3b9e9f73");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bf13809-10b0-47d4-9e3c-69eff7fa82cd", "AQAAAAEAACcQAAAAEID4ry55eBcQ6mEMYkvsL7iC570jAXDkYxluP9A07TnGByrtmTmO2R859g2RGjRmAg==", "e7b856c6-3cca-4d20-b150-fee4da89ad41" });
        }
    }
}
