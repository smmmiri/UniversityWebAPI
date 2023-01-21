using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddKeyToCUAndCPTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities",
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
                values: new object[] { "6a0b1b88-03b5-46c1-9ec3-96d671bb7e22", new DateTime(2022, 10, 25, 10, 59, 13, 964, DateTimeKind.Local).AddTicks(8584) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72e9e75d-b820-489e-93f9-51f36639984b", new DateTime(2022, 10, 25, 10, 59, 13, 964, DateTimeKind.Local).AddTicks(8808), "AQAAAAEAACcQAAAAEDjIGvz435RyRL7Mb8NmTlqFztB3j3NNDCwmHNOa6ThqIy2VKAfnqief2oD/fnL5yA==", "e9fc71eb-7f5c-46e3-a0e8-990852b85af1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseUniversities",
                table: "CourseUniversities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseProfessors",
                table: "CourseProfessors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseUniversities");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CourseProfessors");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "e7927b65-5777-4cde-942a-5a7b91d429ee", new DateTime(2022, 10, 24, 16, 27, 43, 371, DateTimeKind.Local).AddTicks(8248) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42f997bb-e441-46aa-b5c3-36f036764603", new DateTime(2022, 10, 24, 16, 27, 43, 371, DateTimeKind.Local).AddTicks(8477), "AQAAAAEAACcQAAAAEJTJ6dN4ejMwbDLUcoUqY0c3jUgakt1WdM4JIDr0Zp3heTKiHOfYzFkl5SmgKqkJmA==", "5a01a4e7-6cd0-4204-abc4-bb3695ac49b7" });
        }
    }
}
