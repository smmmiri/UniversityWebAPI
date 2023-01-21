using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddCreatorAndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Universities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Universities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Students",
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
                name: "CreationDate",
                table: "Professors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Professors",
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
                name: "CreationDate",
                table: "CourseStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "Courses",
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

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "8865d260-2ea8-49f4-9f9a-9d72120ab170");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "a37e0d6a-d213-4388-82bf-1ada9458c5a2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e150861a-9c31-4e9c-a10e-1eeb959021b9", "AQAAAAEAACcQAAAAELawO3y5lCc61iYDJPnG/YEGS3/QkKOMRD6IZ4TyU/DGj8JE25JITGnQDiIO0BiXJA==", "89c1c2f9-43cf-435c-a98c-cb6d14645077" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "ProfessorStudents");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CourseProfessors");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "5b96725c-e7b0-4c32-b7bb-6829043dda7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "7e1f36f2-f12b-42fd-8732-0dafc2820f95");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8dce3da6-496e-41a6-a155-a957e5a77c9a", "AQAAAAEAACcQAAAAEEM2HKbHFoVO0egUDAyhDgyw5c4BKHwSRvjUmxB6UcRldz7wV8Lg9Ib9dIK0pvms0w==", "ac32d8b0-b764-4e67-ae1c-09830a85828d" });
        }
    }
}
