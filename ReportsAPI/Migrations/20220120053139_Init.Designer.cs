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
    [Migration("20220120053139_Init")]
    partial class Init
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
