using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeConstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "ac3d4f51-4b8c-4027-8429-070bb4dc628a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "c6d3b0cf-468b-4fad-a149-afb7fad96e6b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad596ab9-0154-45a4-be2c-8ea85efb5f29", "AQAAAAEAACcQAAAAEDk8MlvYn84UXwSGwwkhiy7d0e9IUgQf7SMV/7XOUAvABU1tZnF90s0TrFEuFQMl3g==", "36b78ef7-6e6a-4e0b-b65b-162bf96445f3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "6d746fc0-55ac-474f-9e4c-7ca32e48a5a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "4663b191-ada0-4bf3-aa30-2652ab4b8a65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc9370e7-f5ec-4e2a-8115-7a800c273469", "AQAAAAEAACcQAAAAEBeCTbxWgh/Uqf612pnrtoTSXskHIgUeeSLTKgvvMfi4sBYpph2yaFi8lLBDJapbJw==", "df409a3d-3c32-4afc-acc3-3aa8048eaa8e" });
        }
    }
}
