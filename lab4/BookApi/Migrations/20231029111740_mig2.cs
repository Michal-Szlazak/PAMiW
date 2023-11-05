using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookApi.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Books",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000);
        }
    }
}
