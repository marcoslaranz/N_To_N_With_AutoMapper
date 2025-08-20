using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OneToN.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTableAccountAddresses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Accounts_AccountId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Addresses");

            migrationBuilder.CreateTable(
                name: "AccountAddresses",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAddresses", x => new { x.AccountId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_AccountAddresses_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountAddresses_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AccountAddresses",
                columns: new[] { "AccountId", "AddressId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 }
                });

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Balance", "Limit" },
                values: new object[] { 500.00m, 150.00m });

            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "Id", "AccountNumber", "Balance", "Limit" },
                values: new object[] { 2, "222", 100.00m, 50.00m });

            migrationBuilder.InsertData(
                table: "AccountAddresses",
                columns: new[] { "AccountId", "AddressId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AccountAddresses_AddressId",
                table: "AccountAddresses",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountAddresses");

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Addresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Accounts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Balance", "Limit" },
                values: new object[] { 100.00m, 50.00m });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                column: "AccountId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                column: "AccountId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_AccountId",
                table: "Addresses",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Accounts_AccountId",
                table: "Addresses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
