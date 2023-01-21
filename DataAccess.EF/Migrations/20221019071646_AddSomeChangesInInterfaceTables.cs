using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddSomeChangesInInterfaceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudents",
                table: "CourseStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseProfessors",
                table: "CourseProfessors");

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
                name: "IsActive",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "CourseUniversities");

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
                name: "IsActive",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "CourseProfessors");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "8902b994-a6b0-441d-84f5-f433cd0823f2", new DateTime(2022, 10, 19, 10, 46, 46, 444, DateTimeKind.Local).AddTicks(9333) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e685efe9-7e72-4306-bbc6-6777fb1d6fdf", new DateTime(2022, 10, 19, 10, 46, 46, 444, DateTimeKind.Local).AddTicks(9555), "AQAAAAEAACcQAAAAEOWlPG3YyRXaT+S66NFNoseoiGUscqHXq/chDRVTXN400qO2+iyAkAC+KB1PsJUw1w==", "b2846660-9935-4bbe-aac0-3d353e067223" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseUniversities",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "CourseProfessors",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "16e19a9b-0b15-45e6-8c45-8863c91fc73c", new DateTime(2022, 10, 18, 18, 49, 26, 913, DateTimeKind.Local).AddTicks(5650) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d91d3ae9-e08b-4c45-93d6-ba5396da1195", new DateTime(2022, 10, 18, 18, 49, 26, 913, DateTimeKind.Local).AddTicks(5911), "AQAAAAEAACcQAAAAEACovYMQx5Qtp2yH9RJEBeCifMOIOnaD5qLrZnxs4ihQjfiv/m6pah9q0AU+avJM9A==", "c9dbd1a1-852b-47b9-b5eb-0042a32501c3" });
        }
    }
}
