using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportsAPI.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marketplaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    TypeMarket = table.Column<string>(type: "TEXT", nullable: true),
                    ClientId = table.Column<string>(type: "TEXT", nullable: true),
                    ApiKey = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketplaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetailByPeriods",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    realizationreport_id = table.Column<int>(type: "INTEGER", nullable: false),
                    suppliercontract_code = table.Column<string>(type: "TEXT", nullable: true),
                    rrd_id = table.Column<long>(type: "INTEGER", nullable: false),
                    gi_id = table.Column<int>(type: "INTEGER", nullable: false),
                    subject_name = table.Column<string>(type: "TEXT", nullable: true),
                    nm_id = table.Column<int>(type: "INTEGER", nullable: false),
                    brand_name = table.Column<string>(type: "TEXT", nullable: true),
                    sa_name = table.Column<string>(type: "TEXT", nullable: true),
                    ts_name = table.Column<string>(type: "TEXT", nullable: true),
                    barcode = table.Column<string>(type: "TEXT", nullable: true),
                    doc_type_name = table.Column<string>(type: "TEXT", nullable: true),
                    quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    retail_price = table.Column<int>(type: "INTEGER", nullable: false),
                    retail_amount = table.Column<double>(type: "REAL", nullable: false),
                    sale_percent = table.Column<double>(type: "REAL", nullable: false),
                    commission_percent = table.Column<double>(type: "REAL", nullable: false),
                    office_name = table.Column<string>(type: "TEXT", nullable: true),
                    supplier_oper_name = table.Column<string>(type: "TEXT", nullable: true),
                    order_dt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sale_dt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    rr_dt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    shk_id = table.Column<long>(type: "INTEGER", nullable: false),
                    retail_price_withdisc_rub = table.Column<double>(type: "REAL", nullable: false),
                    delivery_amount = table.Column<int>(type: "INTEGER", nullable: false),
                    return_amount = table.Column<int>(type: "INTEGER", nullable: false),
                    delivery_rub = table.Column<int>(type: "INTEGER", nullable: false),
                    gi_box_type_name = table.Column<string>(type: "TEXT", nullable: true),
                    product_discount_for_report = table.Column<int>(type: "INTEGER", nullable: false),
                    supplier_promo = table.Column<int>(type: "INTEGER", nullable: false),
                    rid = table.Column<long>(type: "INTEGER", nullable: false),
                    ppvz_reward = table.Column<double>(type: "REAL", nullable: false),
                    ppvz_vw = table.Column<double>(type: "REAL", nullable: false),
                    ppvz_vw_nds = table.Column<double>(type: "REAL", nullable: false),
                    ppvz_office_id = table.Column<double>(type: "REAL", nullable: false),
                    ppvz_office_name = table.Column<string>(type: "TEXT", nullable: true),
                    ppvz_supplier_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetailByPeriods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IncomeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SupplierArticle = table.Column<string>(type: "TEXT", nullable: true),
                    TechSize = table.Column<string>(type: "TEXT", nullable: true),
                    BarCode = table.Column<string>(type: "TEXT", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<int>(type: "INTEGER", nullable: false),
                    DateClose = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WarehouseName = table.Column<string>(type: "TEXT", nullable: true),
                    nmId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: true),
                    MarketplaceId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incomes_Marketplaces_MarketplaceId",
                        column: x => x.MarketplaceId,
                        principalTable: "Marketplaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_MarketplaceId",
                table: "Incomes",
                column: "MarketplaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "ReportDetailByPeriods");

            migrationBuilder.DropTable(
                name: "Marketplaces");
        }
    }
}
