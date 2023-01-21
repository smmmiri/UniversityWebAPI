using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeStudentRelationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRelations_Courses_CourseId",
                table: "StudentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRelations_Semesters_SemesterId",
                table: "StudentRelations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRelations_CourseId",
                table: "StudentRelations");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentRelations");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "StudentRelations",
                newName: "ProfessorRelationsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRelations_SemesterId",
                table: "StudentRelations",
                newName: "IX_StudentRelations_ProfessorRelationsId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRelations_ProfessorRelations_ProfessorRelationsId",
                table: "StudentRelations",
                column: "ProfessorRelationsId",
                principalTable: "ProfessorRelations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRelations_ProfessorRelations_ProfessorRelationsId",
                table: "StudentRelations");

            migrationBuilder.RenameColumn(
                name: "ProfessorRelationsId",
                table: "StudentRelations",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentRelations_ProfessorRelationsId",
                table: "StudentRelations",
                newName: "IX_StudentRelations_SemesterId");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "StudentRelations",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_StudentRelations_CourseId",
                table: "StudentRelations",
                column: "CourseId");

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
        }
    }
}
