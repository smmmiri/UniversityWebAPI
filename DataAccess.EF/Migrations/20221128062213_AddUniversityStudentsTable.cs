using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddUniversityStudentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityStudents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "99cb86a1-b087-4327-9a23-d373e1012b93", new DateTime(2022, 11, 28, 9, 52, 13, 294, DateTimeKind.Local).AddTicks(244) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd020138-c589-4175-ba48-7c925f691c23", new DateTime(2022, 11, 28, 9, 52, 13, 294, DateTimeKind.Local).AddTicks(506), "AQAAAAEAACcQAAAAED4h6JxS5oBsDHWv8JqDQgC2tAOf8FP/tlme1hDMBQ/VI+DxU6qK0oqpWDGt2jUKJg==", "f9ccdd2a-21af-491c-ae6b-ceec92e2728d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityStudents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "bec72aac-7d68-4e7b-a25f-1e61f741ea72", new DateTime(2022, 11, 23, 10, 47, 9, 404, DateTimeKind.Local).AddTicks(6403) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ba738a6-58a2-4cdb-992d-b7418315f955", new DateTime(2022, 11, 23, 10, 47, 9, 404, DateTimeKind.Local).AddTicks(6635), "AQAAAAEAACcQAAAAEDf7asbE2sEd5RVssXGkMQk+ZgzYYYrFlN8/iiyJucOHcAXWWwuzrbufMUuJ4lVxIw==", "cde58b3a-c730-4526-8f01-084a6d9815ae" });
        }
    }
}
