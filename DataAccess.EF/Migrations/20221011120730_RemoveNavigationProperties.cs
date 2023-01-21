using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class RemoveNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorStudents",
                table: "ProfessorStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseProfessors",
                table: "CourseProfessors");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "ProfessorStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "ProfessorStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "UniversityId",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CourseUniversities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CourseUniversities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "CourseProfessors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CourseProfessors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorStudents",
                table: "ProfessorStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseProfessors",
                table: "CourseProfessors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "cee929e7-884a-4268-8b3f-7df25e9b121f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "e5ddca01-f59f-4870-888c-dff622bb8571");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0c5a523-67b5-4156-bf8a-66056cb448a1", "AQAAAAEAACcQAAAAEL4g3+yg4Rpjphx0oRransFiVjF1/7nldpHXx1QMyPi10pGL1M1bNVAruMI591bOtQ==", "1791955a-ff5e-4f50-b0a7-e3ac319caf1e" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfessorStudents_ProfessorId",
                table: "ProfessorStudents",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseUniversities_CourseId",
                table: "CourseUniversities",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseStudents_CourseId",
                table: "CourseStudents",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseProfessors_CourseId",
                table: "CourseProfessors",
                column: "CourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorStudents",
                table: "ProfessorStudents");

            migrationBuilder.DropIndex(
                name: "IX_ProfessorStudents_ProfessorId",
                table: "ProfessorStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities");

            migrationBuilder.DropIndex(
                name: "IX_CourseUniversities_CourseId",
                table: "CourseUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.DropIndex(
                name: "IX_CourseStudents_CourseId",
                table: "CourseStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseProfessors",
                table: "CourseProfessors");

            migrationBuilder.DropIndex(
                name: "IX_CourseProfessors_CourseId",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "CourseProfessors");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "ProfessorStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "UniversityId",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CourseUniversities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfessorId",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CourseId",
                table: "CourseProfessors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorStudents",
                table: "ProfessorStudents",
                columns: new[] { "ProfessorId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities",
                columns: new[] { "CourseId", "UniversityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseProfessors",
                table: "CourseProfessors",
                columns: new[] { "CourseId", "ProfessorId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "c9db8628-4459-4e73-8438-028511919f59");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "82fffa2a-8f0e-42c6-b8f4-e8bf8794e3f6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "270cfafa-2328-4130-bd2e-7dfb9bf3973c", "AQAAAAEAACcQAAAAEHGWujjZ/wZ2bnDp9tMRCFg9pZb+0sbPQng8sD/uNjMGtpqHCTr6TZHLb0jNWZjEHw==", "78d0315f-29b7-41c0-8314-f7d222c987dc" });
        }
    }
}
