using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entities.Migrations
{
    public partial class ChangeDatabase11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marketplaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    TypeMarket = table.Column<string>(type: "text", nullable: true),
                    ClientId = table.Column<string>(type: "text", nullable: true),
                    ApiKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marketplaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Postings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    delivery_schema = table.Column<string>(type: "text", nullable: true),
                    order_date = table.Column<string>(type: "text", nullable: true),
                    posting_number = table.Column<string>(type: "text", nullable: true),
                    warehouse_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetailByPeriods",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    realizationreport_id = table.Column<int>(type: "integer", nullable: false),
                    suppliercontract_code = table.Column<string>(type: "text", nullable: true),
                    rrd_id = table.Column<long>(type: "bigint", nullable: false),
                    gi_id = table.Column<int>(type: "integer", nullable: false),
                    subject_name = table.Column<string>(type: "text", nullable: true),
                    nm_id = table.Column<int>(type: "integer", nullable: false),
                    brand_name = table.Column<string>(type: "text", nullable: true),
                    sa_name = table.Column<string>(type: "text", nullable: true),
                    ts_name = table.Column<string>(type: "text", nullable: true),
                    barcode = table.Column<string>(type: "text", nullable: true),
                    doc_type_name = table.Column<string>(type: "text", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    retail_price = table.Column<int>(type: "integer", nullable: false),
                    retail_amount = table.Column<double>(type: "double precision", nullable: false),
                    sale_percent = table.Column<double>(type: "double precision", nullable: false),
                    commission_percent = table.Column<double>(type: "double precision", nullable: false),
                    office_name = table.Column<string>(type: "text", nullable: true),
                    supplier_oper_name = table.Column<string>(type: "text", nullable: true),
                    order_dt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sale_dt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    rr_dt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    shk_id = table.Column<long>(type: "bigint", nullable: false),
                    retail_price_withdisc_rub = table.Column<double>(type: "double precision", nullable: false),
                    delivery_amount = table.Column<int>(type: "integer", nullable: false),
                    return_amount = table.Column<int>(type: "integer", nullable: false),
                    delivery_rub = table.Column<int>(type: "integer", nullable: false),
                    gi_box_type_name = table.Column<string>(type: "text", nullable: true),
                    product_discount_for_report = table.Column<int>(type: "integer", nullable: false),
                    supplier_promo = table.Column<int>(type: "integer", nullable: false),
                    rid = table.Column<long>(type: "bigint", nullable: false),
                    ppvz_reward = table.Column<double>(type: "double precision", nullable: false),
                    ppvz_vw = table.Column<double>(type: "double precision", nullable: false),
                    ppvz_vw_nds = table.Column<double>(type: "double precision", nullable: false),
                    ppvz_office_id = table.Column<double>(type: "double precision", nullable: false),
                    ppvz_office_name = table.Column<string>(type: "text", nullable: true),
                    ppvz_supplier_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetailByPeriods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SupplierArticle = table.Column<string>(type: "text", nullable: true),
                    TechSize = table.Column<string>(type: "text", nullable: true),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    DiscountPercent = table.Column<int>(type: "integer", nullable: false),
                    IsSupply = table.Column<bool>(type: "boolean", nullable: false),
                    IsRealization = table.Column<bool>(type: "boolean", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: true),
                    PromoCodeDiscount = table.Column<int>(type: "integer", nullable: false),
                    WarehouseName = table.Column<string>(type: "text", nullable: true),
                    CountryName = table.Column<string>(type: "text", nullable: true),
                    oblastOkrugName = table.Column<string>(type: "text", nullable: true),
                    regionName = table.Column<string>(type: "text", nullable: true),
                    incomeID = table.Column<int>(type: "integer", nullable: false),
                    saleID = table.Column<string>(type: "text", nullable: true),
                    odid = table.Column<long>(type: "bigint", nullable: false),
                    spp = table.Column<int>(type: "integer", nullable: false),
                    forPay = table.Column<decimal>(type: "numeric", nullable: false),
                    finishedPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    priceWithDisc = table.Column<decimal>(type: "numeric", nullable: false),
                    nmId = table.Column<int>(type: "integer", nullable: false),
                    subject = table.Column<string>(type: "text", nullable: true),
                    category = table.Column<string>(type: "text", nullable: true),
                    brand = table.Column<string>(type: "text", nullable: true),
                    IsStorno = table.Column<bool>(type: "boolean", nullable: false),
                    gNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LastChangeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SupplierArticle = table.Column<string>(type: "text", nullable: true),
                    TechSize = table.Column<string>(type: "text", nullable: true),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsSupply = table.Column<int>(type: "integer", nullable: false),
                    IsRealisation = table.Column<int>(type: "integer", nullable: false),
                    QuantityFull = table.Column<int>(type: "integer", nullable: false),
                    QuantityNotInOrders = table.Column<int>(type: "integer", nullable: false),
                    WarehouseName = table.Column<string>(type: "text", nullable: true),
                    InWayToClient = table.Column<int>(type: "integer", nullable: false),
                    InWayFromClient = table.Column<int>(type: "integer", nullable: false),
                    NmId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    DaysOnSite = table.Column<int>(type: "integer", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    SCCode = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IncomeId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SupplierArticle = table.Column<string>(type: "text", nullable: true),
                    TechSize = table.Column<string>(type: "text", nullable: true),
                    BarCode = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    DateClose = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    WarehouseName = table.Column<string>(type: "text", nullable: true),
                    nmId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    MarketplaceId = table.Column<int>(type: "integer", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    operation_id = table.Column<long>(type: "bigint", nullable: false),
                    operation_type = table.Column<string>(type: "text", nullable: true),
                    operation_date = table.Column<string>(type: "text", nullable: true),
                    operation_type_name = table.Column<string>(type: "text", nullable: true),
                    delivery_charge = table.Column<decimal>(type: "numeric", nullable: false),
                    return_delivery_charge = table.Column<decimal>(type: "numeric", nullable: false),
                    accruals_for_sale = table.Column<decimal>(type: "numeric", nullable: false),
                    sale_commission = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    type = table.Column<string>(type: "text", nullable: true),
                    PostingId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Postings_PostingId",
                        column: x => x.PostingId,
                        principalTable: "Postings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    sku = table.Column<int>(type: "integer", nullable: false),
                    OperationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_MarketplaceId",
                table: "Incomes",
                column: "MarketplaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OperationId",
                table: "Items",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_PostingId",
                table: "Operations",
                column: "PostingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ReportDetailByPeriods");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Marketplaces");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Postings");
        }
    }
}
