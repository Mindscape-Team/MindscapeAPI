using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindscapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUserProfilePicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6fdb8ee9-c254-4841-a6af-5d5730f886d5");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "83558711-4f76-48b9-8695-0f598399cace");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d5f68231-df77-47ee-9b0b-e0d98125c7f4");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfilePicture",
                schema: "identity",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                schema: "identity",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6fdb8ee9-c254-4841-a6af-5d5730f886d5", "4223c68c-8b4b-4680-bd75-47e905c85964", "User", "USER" },
                    { "83558711-4f76-48b9-8695-0f598399cace", "cdbe18a4-fbe4-4989-8063-431610180207", "Admin", "ADMIN" },
                    { "d5f68231-df77-47ee-9b0b-e0d98125c7f4", "a487b866-ff0d-451f-bc01-97013623a1e1", "Doctor", "DOCTOR" }
                });
        }
    }
}
