using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddSemesterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Semesters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemesterType = table.Column<string>(type: "nvarchar(24)", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semesters", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "151ba4c5-87e9-402f-b5be-0bea1d8b51a2", new DateTime(2022, 10, 31, 16, 15, 27, 280, DateTimeKind.Local).AddTicks(1503) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec23659c-e2d4-4010-9dae-30eb81e38031", new DateTime(2022, 10, 31, 16, 15, 27, 280, DateTimeKind.Local).AddTicks(1806), "AQAAAAEAACcQAAAAENJmEn+qmPJeft7JaQ/d8IMUTHCQAtj/Dty1jnaUDRY46NOJITwSDmNcR65hQU7ejg==", "a79facd1-0711-4f3c-a597-0456bd7d546f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Semesters");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "0f04a5d0-5543-4f0c-bb39-bdef3fed2097", new DateTime(2022, 10, 29, 9, 56, 55, 438, DateTimeKind.Local).AddTicks(9385) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8634a082-f6ea-412f-b725-b393cc170e8b", new DateTime(2022, 10, 29, 9, 56, 55, 438, DateTimeKind.Local).AddTicks(9621), "AQAAAAEAACcQAAAAEPJuaTbqWIaBbszDtxy6VEjnaRsBJ5Eeiyhg93LrYRcPUBSqSF20S3BJ/wq0iiCflw==", "d8466af5-2a73-4289-983d-0c67bd52ebfe" });
        }
    }
}
