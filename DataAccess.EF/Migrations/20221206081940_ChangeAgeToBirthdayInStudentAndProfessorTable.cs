using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeAgeToBirthdayInStudentAndProfessorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "Professors");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Professors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Professors");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Professors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "525c7791-e862-4686-93cb-46ec3def4df6", new DateTime(2022, 11, 30, 14, 50, 50, 474, DateTimeKind.Local).AddTicks(1316) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d35ef190-9a0f-40d0-a93b-11affefb9096", new DateTime(2022, 11, 30, 14, 50, 50, 474, DateTimeKind.Local).AddTicks(1571), "AQAAAAEAACcQAAAAEEYm3IPTLbI4lfZgx+vzA4DHoLF23WjHqiHt1MLBfWTuitrS4tKbEo+QCp8ZVktdtA==", "4955f541-1e81-4980-9b9a-dd2b0306db50" });
        }
    }
}
