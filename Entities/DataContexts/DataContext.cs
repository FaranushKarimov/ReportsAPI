using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.DataContexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<ReportDetailByPeriod>ReportDetailByPeriods { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Posting> Postings { get; set; }
        public DbSet<Item> Items { get; set; }

        // Ozon stuff
        // public DbSet<Posting> Postings { get; set; }
        // public DbSet<TransactionResult> TransactionResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
