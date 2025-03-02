using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindscapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class NullableProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "0e6c2564-80ff-4645-983d-1e94fcd0dc12");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "b62852fa-b1f4-4240-9826-f37e1ee3f6fd");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dee84584-a9c2-41a9-be56-29a6c6f49250");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                schema: "identity",
                table: "Users",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                schema: "identity",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0e6c2564-80ff-4645-983d-1e94fcd0dc12", "5439c69e-9d2c-446d-88e0-c8e2dfcbb741", "Admin", "ADMIN" },
                    { "b62852fa-b1f4-4240-9826-f37e1ee3f6fd", "5422e64f-68f1-4123-a1a1-84943bf47959", "User", "USER" },
                    { "dee84584-a9c2-41a9-be56-29a6c6f49250", "5e8bdb7c-2bd0-4bed-b5c1-d1a59fcd806a", "Doctor", "DOCTOR" }
                });
        }
    }
}
