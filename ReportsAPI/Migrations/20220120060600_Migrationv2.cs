using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportsAPI.Migrations
{
    public partial class Migrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    retail_amount = table.Column<string>(type: "TEXT", nullable: true),
                    sale_percent = table.Column<int>(type: "INTEGER", nullable: false),
                    commission_percent = table.Column<string>(type: "TEXT", nullable: true),
                    office_name = table.Column<string>(type: "TEXT", nullable: true),
                    supplier_oper_name = table.Column<string>(type: "TEXT", nullable: true),
                    order_dt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    sale_dt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    rr_dt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    shk_id = table.Column<long>(type: "INTEGER", nullable: false),
                    retail_price_withdisc_rub = table.Column<string>(type: "TEXT", nullable: true),
                    delivery_amount = table.Column<int>(type: "INTEGER", nullable: false),
                    return_amount = table.Column<int>(type: "INTEGER", nullable: false),
                    delivery_rub = table.Column<int>(type: "INTEGER", nullable: false),
                    gi_box_type_name = table.Column<string>(type: "TEXT", nullable: true),
                    product_discount_for_report = table.Column<int>(type: "INTEGER", nullable: false),
                    supplier_promo = table.Column<int>(type: "INTEGER", nullable: false),
                    rid = table.Column<long>(type: "INTEGER", nullable: false),
                    ppvz_reward = table.Column<string>(type: "TEXT", nullable: true),
                    ppvz_vw = table.Column<string>(type: "TEXT", nullable: true),
                    ppvz_vw_nds = table.Column<string>(type: "TEXT", nullable: true),
                    ppvz_office_id = table.Column<int>(type: "INTEGER", nullable: false),
                    ppvz_office_name = table.Column<string>(type: "TEXT", nullable: true),
                    ppvz_supplier_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetailByPeriods", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDetailByPeriods");
        }
    }
}
