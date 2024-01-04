using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApi.Migrations
{
    /// <inheritdoc />
    public partial class AuthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Dino Breitenberg", "Sports & Health maroon South Dakota Incredible Course CFA Franc BEAC Kina Bulgarian Lev Avon invoice", "Incredible Small" },
                    { 2, "Maximilian Luettgen", "e-commerce Direct bypassing sensor bandwidth Handmade Steel Car revolutionary Moldovan Leu Grocery channels", "1080p Cotton" },
                    { 3, "Camryn Gorczany", "Indonesia magenta Administrator Berkshire Bedfordshire Savings Account teal Shoes, Movies & Kids American Samoa Home Loan Account", "Coordinator Small" },
                    { 4, "Hailey Buckridge", "repurpose payment Universal Visionary Ergonomic Rubber Pizza Savings Account Inverse Gorgeous Wooden Mouse TCP Licensed Rubber Ball", "IB orange" },
                    { 5, "Sherman Johns", "Incredible Rubber Intranet Specialist reboot UAE Dirham Technician synergize front-end fuchsia", "open-source Grass-roots" },
                    { 6, "Maci Stracke", "Usability Fantastic Soft Fish teal copy Handcrafted Borders Team-oriented blockchains analyzer mobile", "RSS Netherlands Antilles" },
                    { 7, "Bennett Aufderhar", "Summit Licensed Senior deposit explicit Frozen 1080p HTTP moderator Generic", "Personal Loan Account overriding" },
                    { 8, "Andrew Metz", "Tasty Steel Towels Corporate Savings Account Personal Loan Account Function-based index Integration Checking Account copying Assimilated", "Refined Refined Granite Shoes" },
                    { 9, "Gregoria Okuneva", "Clothing, Home & Books invoice Sri Lanka Rupee Identity deposit Creative Facilitator Sudanese Pound e-tailers redundant", "array Computers, Grocery & Books" },
                    { 10, "Lori Cormier", "parse Identity Investment Account incentivize value-added Vermont Intranet RAM Industrial synthesizing", "Electronics & Health Representative" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "PasswordHash", "PasswordSalt", "Role", "Username" },
                values: new object[] { 1234145134, new DateTime(2024, 1, 4, 10, 21, 48, 674, DateTimeKind.Local).AddTicks(3069), "admin@admin", new byte[] { 201, 204, 239, 115, 1, 219, 121, 5, 93, 179, 25, 174, 212, 136, 72, 199, 172, 216, 66, 209, 158, 144, 195, 9, 53, 68, 187, 78, 17, 176, 5, 161, 96, 156, 196, 82, 236, 25, 173, 135, 137, 189, 35, 211, 22, 43, 188, 125, 13, 58, 89, 7, 177, 154, 136, 168, 101, 230, 176, 59, 140, 43, 238, 87 }, new byte[] { 232, 136, 51, 203, 86, 185, 77, 174, 187, 0, 165, 65, 44, 183, 168, 240, 73, 159, 224, 5, 156, 197, 161, 201, 90, 252, 202, 180, 178, 106, 107, 212, 175, 171, 247, 132, 198, 11, 73, 20, 72, 185, 7, 226, 225, 5, 190, 214, 225, 155, 237, 100, 190, 98, 66, 166, 201, 81, 136, 99, 251, 162, 62, 167, 183, 246, 210, 51, 176, 192, 181, 251, 28, 76, 191, 191, 240, 200, 24, 161, 68, 223, 162, 196, 123, 174, 115, 11, 244, 238, 135, 158, 80, 226, 228, 221, 224, 208, 244, 182, 218, 70, 72, 222, 1, 25, 36, 79, 193, 27, 241, 109, 197, 100, 104, 118, 214, 153, 61, 74, 93, 221, 220, 179, 200, 168, 185, 163 }, "Admin", "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
