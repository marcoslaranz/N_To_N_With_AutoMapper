using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace N_To_N_With_AutoMapper.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateRelationAndFeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "Limit" },
                values: new object[] { 1, "123", 100.00m, 50.00m });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AccountId", "City" },
                values: new object[,]
                {
                    { 1, 1, "Auckland" },
                    { 2, 1, "Hamilton" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
