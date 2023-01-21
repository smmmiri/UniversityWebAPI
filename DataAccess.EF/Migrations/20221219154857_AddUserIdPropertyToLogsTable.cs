using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddUserIdPropertyToLogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Logs",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "9dba497c-d50d-4787-a3bb-e1a42ca85752", new DateTime(2022, 12, 19, 19, 18, 57, 444, DateTimeKind.Local).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5059ad37-ef4f-4b81-858b-2a53af45be79", new DateTime(2022, 12, 19, 19, 18, 57, 444, DateTimeKind.Local).AddTicks(2432), "AQAAAAEAACcQAAAAEDJgJDDiX4StgchnGFl+Fk8EEYrtLog3OHOPoD36MPrTHuL5PNYCUmVPKj4gnoX6ig==", "42f8ab72-2c63-43a7-910e-a3dff2beb170" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "d3abc58b-bb4e-4ee0-91c7-b1e1923c6fc5", new DateTime(2022, 12, 19, 13, 5, 57, 340, DateTimeKind.Local).AddTicks(9784) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f873fc3e-dd2b-4075-85ba-3bf6ed73ede2", new DateTime(2022, 12, 19, 13, 5, 57, 341, DateTimeKind.Local).AddTicks(24), "AQAAAAEAACcQAAAAEA+p/RArAzq5qZ9mZYLk4yIDi/KVbAbeSuFZbeNIjkj3+qBSJCnPWtYj2r/3JfxmaA==", "c3421260-6a37-4dec-bc2a-2ca826183217" });
        }
    }
}
