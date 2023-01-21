using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeNameOfInterfaceTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "a67f0352-578a-47d5-8f7b-f591784e14fe", new DateTime(2022, 11, 2, 13, 21, 7, 311, DateTimeKind.Local).AddTicks(4934) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eaeef6e1-f06f-4455-8007-11ff03808c2b", new DateTime(2022, 11, 2, 13, 21, 7, 311, DateTimeKind.Local).AddTicks(5207), "AQAAAAEAACcQAAAAEKM1LDpHobdoZvTWN+XDIGRvNgyvPcEunG/EvgUW/mli0vMlOCDhvX51H5U/ouKOcg==", "b3ef4d1d-90cf-433a-8f5f-960e5dfce450" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "8eb9cc7d-ac94-4843-82f5-b1d593c06053", new DateTime(2022, 11, 2, 13, 6, 34, 369, DateTimeKind.Local).AddTicks(928) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "776d6b48-9398-445b-b910-b25934978dee", new DateTime(2022, 11, 2, 13, 6, 34, 369, DateTimeKind.Local).AddTicks(1163), "AQAAAAEAACcQAAAAEFmttbYPE6dbdlmaLxr9i5TEsDy+eyGWzudVPkpd9LigHcsTT71rYcAH6nEIJXsAEw==", "919095b9-29d3-4475-b4f9-0fd4eded0a2a" });
        }
    }
}
