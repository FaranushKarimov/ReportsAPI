using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<ReportDetailByPeriod>ReportDetailByPeriods { get; set; }

        // Ozon stuff
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<Item> Items { get; set; }

        // Stock
        public DbSet<WhItem> WhItems { get; set; }
        public DbSet<TotalItem> TotalItems { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<StockResults> StockResults { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
