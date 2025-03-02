using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindscapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ab75e00c-1fcb-4e50-955e-a8c9b3b50125");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c3f9f594-d60c-42ac-bfd8-b8d0c108ac7c");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c7e0b810-2fbe-41fe-897a-5d41afaba88f");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "identity",
                table: "Users",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "22af899f-f14d-44b2-b0c9-f783dc2c5a1e", "50389d7f-66c2-48a5-a3ca-3bfaa1a7068e", "User", "USER" },
                    { "af317302-970b-4a48-8280-fe006e605191", "0ffe935f-0f8e-4436-a727-e2960326fcff", "Doctor", "DOCTOR" },
                    { "d2e95b49-38d4-4458-ab59-9c319c5ceaaa", "e8418ed5-1f09-4264-8002-d51ba128d36d", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "22af899f-f14d-44b2-b0c9-f783dc2c5a1e");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "af317302-970b-4a48-8280-fe006e605191");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d2e95b49-38d4-4458-ab59-9c319c5ceaaa");

            migrationBuilder.DropColumn(
                name: "Address",
                schema: "identity",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ab75e00c-1fcb-4e50-955e-a8c9b3b50125", "7588da85-da88-4200-ac72-ff1960b9fab4", "User", "USER" },
                    { "c3f9f594-d60c-42ac-bfd8-b8d0c108ac7c", "a40f16ef-0228-4277-83d0-ffc5d26133e1", "Doctor", "DOCTOR" },
                    { "c7e0b810-2fbe-41fe-897a-5d41afaba88f", "faff2297-2ff1-4c15-9705-d6a917d4bd84", "Admin", "ADMIN" }
                });
        }
    }
}
