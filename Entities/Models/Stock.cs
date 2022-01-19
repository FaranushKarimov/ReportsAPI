using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Incomes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("IncomeId")]
        public int IncomeId { get; set; }
        [JsonPropertyName("Number")]
        public string? Number { get; set; }
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; } [JsonPropertyName("LastChangeDate")]
        public DateTime LastChangeDate { get; set; }
        [JsonPropertyName("SupplierArticle")]
        public string SupplierArticle { get; set; }
        [JsonPropertyName("TechSize")]
        public string TechSize { get; set; }
        [JsonPropertyName("BarCode")]
        public string BarCode { get; set; }
        [JsonPropertyName("Quantity")]
        public int Quantity { get; set; }
        [JsonPropertyName("TotalPrice")]
        public int TotalPrice { get; set; }
        [JsonPropertyName("DateClose")]
        public DateTime DateClose { get; set; }
        [JsonPropertyName("WarehouseName")]
        public string WarehouseName { get; set; }
        [JsonPropertyName("nmId")]
        public int nmId { get; set; }
        [JsonPropertyName("Status")]
        public string Status { get; set; }
        public Marketplace Marketplace { get; set; }
    }
}
