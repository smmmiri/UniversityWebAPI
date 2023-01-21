using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddMoreIdentityCustomFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Universities",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "Universities",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Professors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "Professors",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "CourseStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "CourseStudents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "AspNetRoles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "ModifierId",
                table: "AspNetRoles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "cb2c3dae-f434-4ad3-ac63-e9b4a9eec01b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "0f7ea692-c49c-48ea-8b0f-a895e82f6788");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03e17125-340a-4ccd-a994-6732f667a308", "AQAAAAEAACcQAAAAEP9+uhqvCf+Owq6pZW4SSSzQevqw+f1Yi4NldtxNdfFzC7MVPQ1aL1daRVzCCX7gIw==", "e7aaffaa-e9f5-44c0-ae90-2a06ab2a13fc" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "Universities");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "Professors");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "CourseStudents");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "AspNetRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "f9a58c88-a4a4-46f1-bba0-75992c740102");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "7c0d1da8-f35d-4def-b359-f882fc97301b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdc83ec3-3254-47de-a6ab-57b04db65a2a", "AQAAAAEAACcQAAAAEFGSzdHiekRrAxBsLjbi0uMrn+u7BXo7aCqQfjZ4BsbQAM/w8lIe2WTB8zKSC/aifw==", "201cd2bc-e89a-4720-9f56-330cf5de6e77" });
        }
    }
}
