using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneToN.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddingFeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountAddresses",
                columns: new[] { "AccountId", "AddressId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City" },
                values: new object[,]
                {
                    { 3, "Wellington" },
                    { 4, "Chirschurch" }
                });

            migrationBuilder.InsertData(
                table: "AccountAddresses",
                columns: new[] { "AccountId", "AddressId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 2, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountAddresses",
                keyColumns: new[] { "AccountId", "AddressId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AccountAddresses",
                keyColumns: new[] { "AccountId", "AddressId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "AccountAddresses",
                keyColumns: new[] { "AccountId", "AddressId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
