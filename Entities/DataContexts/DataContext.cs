using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataContexts
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }
        public DbSet<Incomes> Stocks { get; set; }
        public DbSet<Marketplace> Marketplaces { get; set; }
        public DbSet<ReportDetailByPeriod>ReportDetailByPeriods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
