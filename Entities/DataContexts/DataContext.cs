using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        // WB
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<ReportDetailByPeriod>ReportDetailByPeriods { get; set; }
        public DbSet<ReportsAPI.Models.OrderResult> WBOrders { get; set; }

        //--------------------------------------
        // Ozon stuff
        public DbSet<Item> Items { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<Operation> Operations { get; set; }

        // Stock
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<WhItem> WhItems { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<TotalItem> TotalItems { get; set; }
        public DbSet<StockResults> StockResults { get; set; }

        // Posting
        public DbSet<Product> Products { get; set; }
        public DbSet<ItemServices> ItemServices { get; set; }
        public DbSet<AnalyticsData> AnalyticsDatas { get; set; }
        public DbSet<FinancialData> FinancialDatas { get; set; }
        public DbSet<PostingResults> PostingResults { get; set; }
        public DbSet<PostingServices> PostingServices { get; set; }
        public DbSet<PostingResultResult> PostingResultResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
