using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ChangeFluentValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "EC29CDAF-A7BB-4BB4-9E04-640E2FC281D9",
                columns: new[] { "ConcurrencyStamp", "CreationDate" },
                values: new object[] { "0f04a5d0-5543-4f0c-bb39-bdef3fed2097", new DateTime(2022, 10, 29, 9, 56, 55, 438, DateTimeKind.Local).AddTicks(9385) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92C9AD1E-6CE5-4CA0-A79A-919407EA4069",
                columns: new[] { "ConcurrencyStamp", "CreationDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8634a082-f6ea-412f-b725-b393cc170e8b", new DateTime(2022, 10, 29, 9, 56, 55, 438, DateTimeKind.Local).AddTicks(9621), "AQAAAAEAACcQAAAAEPJuaTbqWIaBbszDtxy6VEjnaRsBJ5Eeiyhg93LrYRcPUBSqSF20S3BJ/wq0iiCflw==", "d8466af5-2a73-4289-983d-0c67bd52ebfe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
