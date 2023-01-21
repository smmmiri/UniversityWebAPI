using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddUniversityProfessorsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityRelations");

            migrationBuilder.CreateTable(
                name: "UniversityProfessors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProfessorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityProfessors", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "bec72aac-7d68-4e7b-a25f-1e61f741ea72", new DateTime(2022, 11, 23, 10, 47, 9, 404, DateTimeKind.Local).AddTicks(6403) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ba738a6-58a2-4cdb-992d-b7418315f955", new DateTime(2022, 11, 23, 10, 47, 9, 404, DateTimeKind.Local).AddTicks(6635), "AQAAAAEAACcQAAAAEDf7asbE2sEd5RVssXGkMQk+ZgzYYYrFlN8/iiyJucOHcAXWWwuzrbufMUuJ4lVxIw==", "cde58b3a-c730-4526-8f01-084a6d9815ae" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityProfessors");

            migrationBuilder.CreateTable(
                name: "UniversityRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SemesterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UniversityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityRelations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniversityRelations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UniversityRelations_Semesters_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semesters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UniversityRelations_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "84d868a9-0cd9-4f51-bd5e-6a8c8348970a", new DateTime(2022, 11, 14, 9, 55, 17, 758, DateTimeKind.Local).AddTicks(4816) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "785b3015-a3c7-4cc8-b38a-7ad85abde1b5", new DateTime(2022, 11, 14, 9, 55, 17, 758, DateTimeKind.Local).AddTicks(5059), "AQAAAAEAACcQAAAAEAbJcNlt7I2nSmqlMeqSjg1bAIQuoRnkm4/UWUjU8dEALsv0gtC6G46VkfkPvFib1w==", "163c35fe-4c6e-432f-bacd-369a593af54e" });

            migrationBuilder.CreateIndex(
                name: "IX_UniversityRelations_CourseId",
                table: "UniversityRelations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityRelations_SemesterId",
                table: "UniversityRelations",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_UniversityRelations_UniversityId",
                table: "UniversityRelations",
                column: "UniversityId");
        }
    }
}
