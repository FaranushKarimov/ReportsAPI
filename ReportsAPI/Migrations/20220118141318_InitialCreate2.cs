using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportsAPI.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MarketplaceId",
                table: "Stocks",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_MarketplaceId",
                table: "Stocks",
                column: "MarketplaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Marketplaces_MarketplaceId",
                table: "Stocks",
                column: "MarketplaceId",
                principalTable: "Marketplaces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Marketplaces_MarketplaceId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_MarketplaceId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "MarketplaceId",
                table: "Stocks");
        }
    }
}
