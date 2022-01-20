using Microsoft.EntityFrameworkCore.Migrations;

namespace ReportsAPI.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "sale_percent",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "retail_price_withdisc_rub",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "retail_amount",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ppvz_vw_nds",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ppvz_vw",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ppvz_reward",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ppvz_office_id",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<double>(
                name: "commission_percent",
                table: "ReportDetailByPeriods",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "sale_percent",
                table: "ReportDetailByPeriods",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "retail_price_withdisc_rub",
                table: "ReportDetailByPeriods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "retail_amount",
                table: "ReportDetailByPeriods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "ppvz_vw_nds",
                table: "ReportDetailByPeriods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "ppvz_vw",
                table: "ReportDetailByPeriods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "ppvz_reward",
                table: "ReportDetailByPeriods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "ppvz_office_id",
                table: "ReportDetailByPeriods",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "commission_percent",
                table: "ReportDetailByPeriods",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
