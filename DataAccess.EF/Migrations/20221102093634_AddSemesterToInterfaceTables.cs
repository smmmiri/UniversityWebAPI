using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddSemesterToInterfaceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseStudents");

            migrationBuilder.DropTable(
                name: "CourseUniversities");

            migrationBuilder.CreateTable(
                name: "CourseSemesterStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemesterStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSemesterStudents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSemesterStudents_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSemesterStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseSemesterUniversities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemesterUniversities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseSemesterUniversities_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSemesterUniversities_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseSemesterUniversities_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "8eb9cc7d-ac94-4843-82f5-b1d593c06053", new DateTime(2022, 11, 2, 13, 6, 34, 369, DateTimeKind.Local).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "776d6b48-9398-445b-b910-b25934978dee", new DateTime(2022, 11, 2, 13, 6, 34, 369, DateTimeKind.Local).AddTicks(1163), "AQAAAAEAACcQAAAAEFmttbYPE6dbdlmaLxr9i5TEsDy+eyGWzudVPkpd9LigHcsTT71rYcAH6nEIJXsAEw==", "919095b9-29d3-4475-b4f9-0fd4eded0a2a" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterStudents_CourseId",
                table: "CourseSemesterStudents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterStudents_SemesterId",
                table: "CourseSemesterStudents",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterStudents_StudentId",
                table: "CourseSemesterStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterUniversities_CourseId",
                table: "CourseSemesterUniversities",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterUniversities_SemesterId",
                table: "CourseSemesterUniversities",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemesterUniversities_UniversityId",
                table: "CourseSemesterUniversities",
                column: "UniversityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSemesterStudents");

            migrationBuilder.DropTable(
                name: "CourseSemesterUniversities");

            migrationBuilder.CreateTable(
                name: "CourseStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<double>(type: "float", nullable: false),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseStudents_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CourseUniversities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseUniversities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseUniversities_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CourseUniversities_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_CourseId",
                table: "CourseStudents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_StudentId",
                table: "CourseStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUniversities_CourseId",
                table: "CourseUniversities",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUniversities_UniversityId",
                table: "CourseUniversities",
                column: "UniversityId");
        }
    }
}
