using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddGlobalQueryForUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "e7927b65-5777-4cde-942a-5a7b91d429ee", new DateTime(2022, 10, 24, 16, 27, 43, 371, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f997bb-e441-46aa-b5c3-36f036764603", new DateTime(2022, 10, 24, 16, 27, 43, 371, DateTimeKind.Local).AddTicks(8477), "AQAAAAEAACcQAAAAEJTJ6dN4ejMwbDLUcoUqY0c3jUgakt1WdM4JIDr0Zp3heTKiHOfYzFkl5SmgKqkJmA==", "5a01a4e7-6cd0-4204-abc4-bb3695ac49b7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "9c3fe140-a036-4cf8-8742-91c5181f83c1", new DateTime(2022, 10, 19, 14, 42, 31, 73, DateTimeKind.Local).AddTicks(5984) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4746056f-da16-42c4-98ed-097b1d1ddb45", new DateTime(2022, 10, 19, 14, 42, 31, 73, DateTimeKind.Local).AddTicks(6213), "AQAAAAEAACcQAAAAECi80A9DBZaKIkDLtwaA4gKtGZ7F/zb1QNlXfWjH+xoMCtNG38KyS/eJHmT3vfSb8w==", "c11a131d-3324-452f-82e9-c15cd6317aa8" });
        }
    }
}
