using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CreateLogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StackTrace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Exception = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "bdd966e3-8cf6-45f9-9cdb-58e71f5547cf", new DateTime(2022, 12, 6, 16, 24, 21, 196, DateTimeKind.Local).AddTicks(9650) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a60e41c4-35f5-4a09-a45c-ac85e8071c30", new DateTime(2022, 12, 6, 16, 24, 21, 196, DateTimeKind.Local).AddTicks(9873), "AQAAAAEAACcQAAAAEJKXvkN+G6IwZboOMSasOWz5SYUxr94Wg2iLCLNQ7lSeuQPtUfRcaX81rH+t///ehA==", "6a7933c0-1104-4001-be21-89731d64a2e6" });
        }
    }
}
