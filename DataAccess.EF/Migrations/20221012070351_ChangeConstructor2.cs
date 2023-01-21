using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeConstructor2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "b57723fb-6e46-4807-8647-3a43260e7049");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "167e4a00-9e20-4b6b-807a-01ce26e0e645");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed78dd30-74d7-44ff-a21d-a774d0113611", "AQAAAAEAACcQAAAAENEatJCkAyLU/RwQS3l8UH3q7B/Z8ZpuqMhPcLomU6qPOT8hss+QobbL0kYuwijZUg==", "584f74bc-12fe-4b08-b15d-be5b173e6bee" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
