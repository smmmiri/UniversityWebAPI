using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeNameOfInterfaceTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterProfessors_Courses_CourseId",
                table: "CourseSemesterProfessors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterProfessors_Professors_ProfessorId",
                table: "CourseSemesterProfessors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterProfessors_Semesters_SemesterId",
                table: "CourseSemesterProfessors");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterStudents_Courses_CourseId",
                table: "CourseSemesterStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterStudents_Semesters_SemesterId",
                table: "CourseSemesterStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterStudents_Students_StudentId",
                table: "CourseSemesterStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterUniversities_Courses_CourseId",
                table: "CourseSemesterUniversities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterUniversities_Semesters_SemesterId",
                table: "CourseSemesterUniversities");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseSemesterUniversities_Universities_UniversityId",
                table: "CourseSemesterUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSemesterUniversities",
                table: "CourseSemesterUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSemesterStudents",
                table: "CourseSemesterStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseSemesterProfessors",
                table: "CourseSemesterProfessors");

            migrationBuilder.RenameTable(
                name: "CourseSemesterUniversities",
                newName: "UniversityRelations");

            migrationBuilder.RenameTable(
                name: "CourseSemesterStudents",
                newName: "StudentRelations");

            migrationBuilder.RenameTable(
                name: "CourseSemesterProfessors",
                newName: "ProfessorRelations");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterUniversities_UniversityId",
                table: "UniversityRelations",
                newName: "IX_UniversityRelations_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterUniversities_SemesterId",
                table: "UniversityRelations",
                newName: "IX_UniversityRelations_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterUniversities_CourseId",
                table: "UniversityRelations",
                newName: "IX_UniversityRelations_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterStudents_StudentId",
                table: "StudentRelations",
                newName: "IX_StudentRelations_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterStudents_SemesterId",
                table: "StudentRelations",
                newName: "IX_StudentRelations_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterStudents_CourseId",
                table: "StudentRelations",
                newName: "IX_StudentRelations_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterProfessors_SemesterId",
                table: "ProfessorRelations",
                newName: "IX_ProfessorRelations_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterProfessors_ProfessorId",
                table: "ProfessorRelations",
                newName: "IX_ProfessorRelations_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseSemesterProfessors_CourseId",
                table: "ProfessorRelations",
                newName: "IX_ProfessorRelations_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniversityRelations",
                table: "UniversityRelations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentRelations",
                table: "StudentRelations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorRelations",
                table: "ProfessorRelations",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorRelations_Courses_CourseId",
                table: "ProfessorRelations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorRelations_Professors_ProfessorId",
                table: "ProfessorRelations",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorRelations_Semesters_SemesterId",
                table: "ProfessorRelations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRelations_Courses_CourseId",
                table: "StudentRelations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRelations_Semesters_SemesterId",
                table: "StudentRelations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRelations_Students_StudentId",
                table: "StudentRelations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityRelations_Courses_CourseId",
                table: "UniversityRelations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityRelations_Semesters_SemesterId",
                table: "UniversityRelations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UniversityRelations_Universities_UniversityId",
                table: "UniversityRelations",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorRelations_Courses_CourseId",
                table: "ProfessorRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorRelations_Professors_ProfessorId",
                table: "ProfessorRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorRelations_Semesters_SemesterId",
                table: "ProfessorRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRelations_Courses_CourseId",
                table: "StudentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRelations_Semesters_SemesterId",
                table: "StudentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRelations_Students_StudentId",
                table: "StudentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityRelations_Courses_CourseId",
                table: "UniversityRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityRelations_Semesters_SemesterId",
                table: "UniversityRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_UniversityRelations_Universities_UniversityId",
                table: "UniversityRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniversityRelations",
                table: "UniversityRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentRelations",
                table: "StudentRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorRelations",
                table: "ProfessorRelations");

            migrationBuilder.RenameTable(
                name: "UniversityRelations",
                newName: "CourseSemesterUniversities");

            migrationBuilder.RenameTable(
                name: "StudentRelations",
                newName: "CourseSemesterStudents");

            migrationBuilder.RenameTable(
                name: "ProfessorRelations",
                newName: "CourseSemesterProfessors");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityRelations_UniversityId",
                table: "CourseSemesterUniversities",
                newName: "IX_CourseSemesterUniversities_UniversityId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityRelations_SemesterId",
                table: "CourseSemesterUniversities",
                newName: "IX_CourseSemesterUniversities_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_UniversityRelations_CourseId",
                table: "CourseSemesterUniversities",
                newName: "IX_CourseSemesterUniversities_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRelations_StudentId",
                table: "CourseSemesterStudents",
                newName: "IX_CourseSemesterStudents_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRelations_SemesterId",
                table: "CourseSemesterStudents",
                newName: "IX_CourseSemesterStudents_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRelations_CourseId",
                table: "CourseSemesterStudents",
                newName: "IX_CourseSemesterStudents_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorRelations_SemesterId",
                table: "CourseSemesterProfessors",
                newName: "IX_CourseSemesterProfessors_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorRelations_ProfessorId",
                table: "CourseSemesterProfessors",
                newName: "IX_CourseSemesterProfessors_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorRelations_CourseId",
                table: "CourseSemesterProfessors",
                newName: "IX_CourseSemesterProfessors_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSemesterUniversities",
                table: "CourseSemesterUniversities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSemesterStudents",
                table: "CourseSemesterStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseSemesterProfessors",
                table: "CourseSemesterProfessors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "a67f0352-578a-47d5-8f7b-f591784e14fe", new DateTime(2022, 11, 2, 13, 21, 7, 311, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaeef6e1-f06f-4455-8007-11ff03808c2b", new DateTime(2022, 11, 2, 13, 21, 7, 311, DateTimeKind.Local).AddTicks(5207), "AQAAAAEAACcQAAAAEKM1LDpHobdoZvTWN+XDIGRvNgyvPcEunG/EvgUW/mli0vMlOCDhvX51H5U/ouKOcg==", "b3ef4d1d-90cf-433a-8f5f-960e5dfce450" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterProfessors_Courses_CourseId",
                table: "CourseSemesterProfessors",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterProfessors_Professors_ProfessorId",
                table: "CourseSemesterProfessors",
                column: "ProfessorId",
                principalTable: "Professors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterProfessors_Semesters_SemesterId",
                table: "CourseSemesterProfessors",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterStudents_Courses_CourseId",
                table: "CourseSemesterStudents",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterStudents_Semesters_SemesterId",
                table: "CourseSemesterStudents",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterStudents_Students_StudentId",
                table: "CourseSemesterStudents",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterUniversities_Courses_CourseId",
                table: "CourseSemesterUniversities",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterUniversities_Semesters_SemesterId",
                table: "CourseSemesterUniversities",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSemesterUniversities_Universities_UniversityId",
                table: "CourseSemesterUniversities",
                column: "UniversityId",
                principalTable: "Universities",
                principalColumn: "Id");
        }
    }
}
