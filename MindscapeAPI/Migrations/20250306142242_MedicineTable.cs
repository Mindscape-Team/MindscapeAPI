using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MindscapeAPI.Migrations
{
    /// <inheritdoc />
    public partial class MedicineTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DosageFrequency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dosage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicineTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicinePhoto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicines_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "identity",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "identity",
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "209f91af-23c2-4b83-b2c8-ea98600b0c89", "545c68ac-8853-4d4c-81fc-4555159f8710", "User", "USER" },
                    { "530970c5-288f-4537-bf6c-2e7a9ee6f2e7", "3fa046a0-9cd3-4abd-9f29-87a579569098", "Doctor", "DOCTOR" },
                    { "5f750c1d-64f8-4cba-93cc-f7a12b4f9859", "678d4c8e-4c34-4c45-be61-da0e21f258d1", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_UserId",
                table: "Medicines",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "209f91af-23c2-4b83-b2c8-ea98600b0c89");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "530970c5-288f-4537-bf6c-2e7a9ee6f2e7");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "Roles",
                keyColumn: "Id",
                keyValue: "5f750c1d-64f8-4cba-93cc-f7a12b4f9859");

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
    }
}
