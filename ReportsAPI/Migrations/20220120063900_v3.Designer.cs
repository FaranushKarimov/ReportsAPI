﻿// <auto-generated />
using System;
using Entities.DataContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ReportsAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220120063900_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("Entities.Models.Incomes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BarCode")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateClose")
                        .HasColumnType("TEXT");

                    b.Property<int>("IncomeId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastChangeDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("MarketplaceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Number")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<string>("SupplierArticle")
                        .HasColumnType("TEXT");

                    b.Property<string>("TechSize")
                        .HasColumnType("TEXT");

                    b.Property<int>("TotalPrice")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WarehouseName")
                        .HasColumnType("TEXT");

                    b.Property<int>("nmId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("MarketplaceId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Entities.Models.Marketplace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ApiKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<string>("TypeMarket")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Marketplaces");
                });

            modelBuilder.Entity("Entities.Models.ReportDetailByPeriod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("barcode")
                        .HasColumnType("TEXT");

                    b.Property<string>("brand_name")
                        .HasColumnType("TEXT");

                    b.Property<double>("commission_percent")
                        .HasColumnType("REAL");

                    b.Property<int>("delivery_amount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("delivery_rub")
                        .HasColumnType("INTEGER");

                    b.Property<string>("doc_type_name")
                        .HasColumnType("TEXT");

                    b.Property<string>("gi_box_type_name")
                        .HasColumnType("TEXT");

                    b.Property<int>("gi_id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("nm_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("office_name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("order_dt")
                        .HasColumnType("TEXT");

                    b.Property<double>("ppvz_office_id")
                        .HasColumnType("REAL");

                    b.Property<string>("ppvz_office_name")
                        .HasColumnType("TEXT");

                    b.Property<double>("ppvz_reward")
                        .HasColumnType("REAL");

                    b.Property<int>("ppvz_supplier_id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("ppvz_vw")
                        .HasColumnType("REAL");

                    b.Property<double>("ppvz_vw_nds")
                        .HasColumnType("REAL");

                    b.Property<int>("product_discount_for_report")
                        .HasColumnType("INTEGER");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("realizationreport_id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("retail_amount")
                        .HasColumnType("REAL");

                    b.Property<int>("retail_price")
                        .HasColumnType("INTEGER");

                    b.Property<double>("retail_price_withdisc_rub")
                        .HasColumnType("REAL");

                    b.Property<int>("return_amount")
                        .HasColumnType("INTEGER");

                    b.Property<long>("rid")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("rr_dt")
                        .HasColumnType("TEXT");

                    b.Property<long>("rrd_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("sa_name")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("sale_dt")
                        .HasColumnType("TEXT");

                    b.Property<double>("sale_percent")
                        .HasColumnType("REAL");

                    b.Property<long>("shk_id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("subject_name")
                        .HasColumnType("TEXT");

                    b.Property<string>("supplier_oper_name")
                        .HasColumnType("TEXT");

                    b.Property<int>("supplier_promo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("suppliercontract_code")
                        .HasColumnType("TEXT");

                    b.Property<string>("ts_name")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("ReportDetailByPeriods");
                });

            modelBuilder.Entity("Entities.Models.Incomes", b =>
                {
                    b.HasOne("Entities.Models.Marketplace", "Marketplace")
                        .WithMany("Stocks")
                        .HasForeignKey("MarketplaceId");

                    b.Navigation("Marketplace");
                });

            modelBuilder.Entity("Entities.Models.Marketplace", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}