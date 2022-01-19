using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public int IncomeId { get; set; }
        public string? Number { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastChangeDate { get; set; }
        public string SupplierArticle { get; set; }
        public string TechSize { get; set; }
        public string BarCode { get; set; }
        public int Quantity { get; set; }
        public int TotalPrice { get; set; }
        public DateTime DateClose { get; set; }
        public string WarehouseName { get; set; }
        public int nmId { get; set; }
        public string Status { get; set; }
        public Marketplace Marketplace { get; set; }
    }
}
