using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class RemoveProfessorStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProfessorStudents");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058",
                column: "ConcurrencyStamp",
                value: "6d746fc0-55ac-474f-9e4c-7ca32e48a5a8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                column: "ConcurrencyStamp",
                value: "4663b191-ada0-4bf3-aa30-2652ab4b8a65");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc9370e7-f5ec-4e2a-8115-7a800c273469", "AQAAAAEAACcQAAAAEBeCTbxWgh/Uqf612pnrtoTSXskHIgUeeSLTKgvvMfi4sBYpph2yaFi8lLBDJapbJw==", "df409a3d-3c32-4afc-acc3-3aa8048eaa8e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProfessorStudents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessorStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessorStudents_Professors_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProfessorStudents_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

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
                name: "IX_ProfessorStudents_StudentId",
                table: "ProfessorStudents",
                column: "StudentId");
        }
    }
}
