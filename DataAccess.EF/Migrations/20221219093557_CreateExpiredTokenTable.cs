using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreateExpiredTokenTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpiredTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpiredTokens", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "d3abc58b-bb4e-4ee0-91c7-b1e1923c6fc5", new DateTime(2022, 12, 19, 13, 5, 57, 340, DateTimeKind.Local).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f873fc3e-dd2b-4075-85ba-3bf6ed73ede2", new DateTime(2022, 12, 19, 13, 5, 57, 341, DateTimeKind.Local).AddTicks(24), "AQAAAAEAACcQAAAAEA+p/RArAzq5qZ9mZYLk4yIDi/KVbAbeSuFZbeNIjkj3+qBSJCnPWtYj2r/3JfxmaA==", "c3421260-6a37-4dec-bc2a-2ca826183217" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpiredTokens");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "de4accbb-a7c0-4f26-a20c-66f8dd174830", new DateTime(2022, 12, 19, 10, 42, 2, 934, DateTimeKind.Local).AddTicks(9697) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b2873b-737b-4749-b8c0-c36096ee2da0", new DateTime(2022, 12, 19, 10, 42, 2, 934, DateTimeKind.Local).AddTicks(9946), "AQAAAAEAACcQAAAAEPcwZO0KCleAafsHwOJjs3xMtXpbvSBuQGMOkkmVqpvKzVmbqp5hf6kD/SNfBJuZuQ==", "4d86fddb-21ce-4a2c-b8c6-8ab0616f170e" });
        }
    }
}
