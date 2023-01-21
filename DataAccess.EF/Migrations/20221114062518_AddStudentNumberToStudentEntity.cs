using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddStudentNumberToStudentEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StudentNumber",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "84d868a9-0cd9-4f51-bd5e-6a8c8348970a", new DateTime(2022, 11, 14, 9, 55, 17, 758, DateTimeKind.Local).AddTicks(4816) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785b3015-a3c7-4cc8-b38a-7ad85abde1b5", new DateTime(2022, 11, 14, 9, 55, 17, 758, DateTimeKind.Local).AddTicks(5059), "AQAAAAEAACcQAAAAEAbJcNlt7I2nSmqlMeqSjg1bAIQuoRnkm4/UWUjU8dEALsv0gtC6G46VkfkPvFib1w==", "163c35fe-4c6e-432f-bacd-369a593af54e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StudentNumber",
                table: "Students");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "69047369-0d91-4974-ab7b-86f103ff8fd1", new DateTime(2022, 11, 2, 13, 53, 35, 161, DateTimeKind.Local).AddTicks(5295) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ec88056-e6d4-48c6-ad7e-ee7272900887", new DateTime(2022, 11, 2, 13, 53, 35, 161, DateTimeKind.Local).AddTicks(5527), "AQAAAAEAACcQAAAAEJkym5lhk+VxDfBXk9lzpb8FvBm+nuqYq0FdHmIUvicBIiaC1o2DvwX3Dq223yZVIA==", "4c762f25-308a-4493-b228-1622b29fdbbb" });
        }
    }
}
