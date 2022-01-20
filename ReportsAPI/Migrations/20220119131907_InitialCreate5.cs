using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportsAPI.Migrations
{
    public partial class InitialCreate5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Marketplaces_MarketplaceId",
                table: "Stocks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks");

            migrationBuilder.RenameTable(
                name: "Stocks",
                newName: "Incomes");

            migrationBuilder.RenameIndex(
                name: "IX_Stocks_MarketplaceId",
                table: "Incomes",
                newName: "IX_Incomes_MarketplaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incomes_Marketplaces_MarketplaceId",
                table: "Incomes",
                column: "MarketplaceId",
                principalTable: "Marketplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incomes_Marketplaces_MarketplaceId",
                table: "Incomes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incomes",
                table: "Incomes");

            migrationBuilder.RenameTable(
                name: "Incomes",
                newName: "Stocks");

            migrationBuilder.RenameIndex(
                name: "IX_Incomes_MarketplaceId",
                table: "Stocks",
                newName: "IX_Stocks_MarketplaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stocks",
                table: "Stocks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Marketplaces_MarketplaceId",
                table: "Stocks",
                column: "MarketplaceId",
                principalTable: "Marketplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
