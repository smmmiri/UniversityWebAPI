using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Universities");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Universities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Professors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseUniversities",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Courses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UniversityId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseProfessors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "AspNetRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "38652836-72f1-425a-9fe2-00c27023b857");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "c2837776-6454-4267-af72-4add3b9e9f73");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1bf13809-10b0-47d4-9e3c-69eff7fa82cd", "AQAAAAEAACcQAAAAEID4ry55eBcQ6mEMYkvsL7iC570jAXDkYxluP9A07TnGByrtmTmO2R859g2RGjRmAg==", "e7b856c6-3cca-4d20-b150-fee4da89ad41" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "AspNetRoles");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Universities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "b57723fb-6e46-4807-8647-3a43260e7049");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "167e4a00-9e20-4b6b-807a-01ce26e0e645");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ed78dd30-74d7-44ff-a21d-a774d0113611", "AQAAAAEAACcQAAAAENEatJCkAyLU/RwQS3l8UH3q7B/Z8ZpuqMhPcLomU6qPOT8hss+QobbL0kYuwijZUg==", "584f74bc-12fe-4b08-b15d-be5b173e6bee" });
        }
    }
}
