using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeCourseProfessorToCourseSemesterProfessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseProfessors");

            migrationBuilder.AddColumn<DateTime>(
                name: "SemesterYear",
                table: "Semesters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "CourseSemesterProfessors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemesterProfessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSemesterProfessors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSemesterProfessors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSemesterProfessors_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterProfessors_CourseId",
                table: "CourseSemesterProfessors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterProfessors_ProfessorId",
                table: "CourseSemesterProfessors",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterProfessors_SemesterId",
                table: "CourseSemesterProfessors",
                column: "SemesterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSemesterProfessors");

            migrationBuilder.DropColumn(
                name: "SemesterYear",
                table: "Semesters");

            migrationBuilder.CreateTable(
                name: "CourseProfessors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseProfessors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseProfessors_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseProfessors_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
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

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfessors_CourseId",
                table: "CourseProfessors",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfessors_ProfessorId",
                table: "CourseProfessors",
                column: "ProfessorId");
        }
    }
}
