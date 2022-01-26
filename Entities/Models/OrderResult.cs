using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReportsAPI.Models
{
    public class OrderResult
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public long number { get; set; }
        public DateTime date { get; set; }
        public DateTime lastChangeDate { get; set; }
        public string supplierArticle { get; set; }
        public string techSize { get; set; }
        public string barcode { get; set; }
        public int quantity { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discountPercent { get; set; }
        public string warehouseName { get; set; }
        public string oblast { get; set; }
        public int incomeID { get; set; }
        public long odid { get; set; }
        public int nmId { get; set; }
        public string subject { get; set; }
        public string category { get; set; }
        public string brand { get; set; }
        public bool isCancel { get; set; }
        public DateTime cancel_dt { get; set; }
        public string gNumber { get; set; }
    }
}
