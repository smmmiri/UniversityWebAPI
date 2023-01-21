using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddSomeChangesInEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8C107E3D-988D-4432-AEF3-B27354E62058");

            migrationBuilder.AddColumn<Guid>(
                name: "UniversityId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "IsActive" },
                values: new object[] { "16e19a9b-0b15-45e6-8c45-8863c91fc73c", new DateTime(2022, 10, 18, 18, 49, 26, 913, DateTimeKind.Local).AddTicks(5650), true });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d91d3ae9-e08b-4c45-93d6-ba5396da1195", new DateTime(2022, 10, 18, 18, 49, 26, 913, DateTimeKind.Local).AddTicks(5911), true, "AQAAAAEAACcQAAAAEACovYMQx5Qtp2yH9RJEBeCifMOIOnaD5qLrZnxs4ihQjfiv/m6pah9q0AU+avJM9A==", "c9dbd1a1-852b-47b9-b5eb-0042a32501c3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniversityId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "IsActive" },
                values: new object[] { "4845b05f-3f00-45af-9b76-8303f504f940", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreationDate", "CreatorId", "IsActive", "ModificationDate", "ModifierId", "Name", "NormalizedName" },
                values: new object[] { "8C107E3D-988D-4432-AEF3-B27354E62058", "bca744f4-58c8-40f9-87dc-accb04abcc72", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), "User", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "IsActive", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c90bb35-cf63-44f9-8c71-32808b73af79", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "AQAAAAEAACcQAAAAELKAilJNBxK4KebneTrdO/9Qz75XkYGMu6nKp8G/ttX3LELab9OKfG/FaKQbq86adg==", "14c5fd09-51ac-45d3-ac09-f8d2e44958f0" });
        }
    }
}
