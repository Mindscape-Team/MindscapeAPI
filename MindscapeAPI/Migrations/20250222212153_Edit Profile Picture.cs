using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindscapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class EditProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c6589051-fcf6-4d09-baef-9ca314b2d252");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c79ee6c1-7974-4f45-a411-76b673d845c2");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "f35c19ca-d592-45fd-aea5-b00f0d887c72");

            migrationBuilder.AlterColumn<string>(
                name: "ProfilePicture",
                schema: "identity",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                schema: "identity",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c6589051-fcf6-4d09-baef-9ca314b2d252", "327ec572-cda2-4993-b170-8f8611e53422", "Admin", "ADMIN" },
                    { "c79ee6c1-7974-4f45-a411-76b673d845c2", "31927c77-578d-41ad-833d-4120fe988023", "User", "USER" },
                    { "f35c19ca-d592-45fd-aea5-b00f0d887c72", "6ac4dc56-8290-4b7b-9145-1afdece8d5f5", "Doctor", "DOCTOR" }
                });
        }
    }
}
