using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class MoveSalaryFromProfessorToProfessorRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Professors");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProfessorRelations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ProfessorRelations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "ProfessorRelations",
                type: "money",
                nullable: false,
                defaultValue: 0m);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProfessorRelations");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProfessorRelations");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "ProfessorRelations");

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Professors",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "89fd9b9c-a9ec-40d6-894f-7bcce7b979c9", new DateTime(2022, 12, 6, 11, 49, 39, 714, DateTimeKind.Local).AddTicks(6216) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f776675d-ea02-412b-9a24-9076e2cd1909", new DateTime(2022, 12, 6, 11, 49, 39, 714, DateTimeKind.Local).AddTicks(6454), "AQAAAAEAACcQAAAAEOApzz7+g3fB2NWwpuM+JalwkJrdZUfSvnxNIhH3/YJ5Z9uk9lev6GPG14Y/3+Rg5w==", "823c7ee4-fb35-4c97-a2df-1bd14f6c27a7" });
        }
    }
}
