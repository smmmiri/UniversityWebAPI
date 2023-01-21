using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddSemesterIdToCourseStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SemesterId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "ae56f326-1231-40c6-ac85-81824d0f3f8e", new DateTime(2022, 11, 2, 10, 41, 9, 315, DateTimeKind.Local).AddTicks(6828) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "589aa16b-e4f4-4c76-85fa-7c0402dcb378", new DateTime(2022, 11, 2, 10, 41, 9, 315, DateTimeKind.Local).AddTicks(7254), "AQAAAAEAACcQAAAAEBSohFrev784N+sh/auQM07P4LEhZPFdR9HbEb0Zm9w5ZbAq43nl33l6gqkV/zJl3Q==", "3b0a4c80-eaba-4b23-b127-9705c34bc247" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "CourseStudents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "9ac43476-1e73-40c0-b6cd-dde045266fe9", new DateTime(2022, 11, 1, 14, 41, 8, 672, DateTimeKind.Local).AddTicks(8508) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ad895a92-04f3-445d-b715-ed2c5e93303c", new DateTime(2022, 11, 1, 14, 41, 8, 672, DateTimeKind.Local).AddTicks(8858), "AQAAAAEAACcQAAAAELbkPQKZVt/PaOF7eweSzyk6a9GmCGOFsJwqdYaeQB7pFgDNLR3WhoQ+4q5E7FWiFg==", "82600f17-bada-4ccc-8550-b16f11b93a31" });
        }
    }
}
