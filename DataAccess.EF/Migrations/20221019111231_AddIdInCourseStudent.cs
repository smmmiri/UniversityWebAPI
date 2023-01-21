using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddIdInCourseStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "8902b994-a6b0-441d-84f5-f433cd0823f2", new DateTime(2022, 10, 19, 10, 46, 46, 444, DateTimeKind.Local).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e685efe9-7e72-4306-bbc6-6777fb1d6fdf", new DateTime(2022, 10, 19, 10, 46, 46, 444, DateTimeKind.Local).AddTicks(9555), "AQAAAAEAACcQAAAAEOWlPG3YyRXaT+S66NFNoseoiGUscqHXq/chDRVTXN400qO2+iyAkAC+KB1PsJUw1w==", "b2846660-9935-4bbe-aac0-3d353e067223" });
        }
    }
}
