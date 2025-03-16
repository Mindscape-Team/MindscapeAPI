using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindscapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicineDateField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "078c9176-bd0f-489d-941b-cd2bdc4cdf30");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "45697096-ddb5-4279-8981-d80b59ddf18b");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "8d8ff29e-e3d3-4b26-adee-63b15a98afb6");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Medicines",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6d26cac3-cda8-4232-ac1e-db831c2a16d7", "bd6a547c-ba19-47af-8a98-16f4f3cd95de", "User", "USER" },
                    { "6fb3123b-dfe6-47e6-a7c3-97823ff77aee", "81d6744d-17c6-4eef-b396-750a8d314a04", "Admin", "ADMIN" },
                    { "ecb25b33-31af-4921-aab7-8017daf651a5", "79910ecd-e19d-48de-b944-cd237e36c99e", "Doctor", "DOCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6d26cac3-cda8-4232-ac1e-db831c2a16d7");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "6fb3123b-dfe6-47e6-a7c3-97823ff77aee");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ecb25b33-31af-4921-aab7-8017daf651a5");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Medicines");

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "078c9176-bd0f-489d-941b-cd2bdc4cdf30", "20c2dd9b-e813-4d69-804e-b7117c82072b", "User", "USER" },
                    { "45697096-ddb5-4279-8981-d80b59ddf18b", "ad414968-c2ca-4671-ba6a-954cedfe011d", "Doctor", "DOCTOR" },
                    { "8d8ff29e-e3d3-4b26-adee-63b15a98afb6", "6fb550bc-7f88-4c62-9421-a02250032456", "Admin", "ADMIN" }
                });
        }
    }
}
