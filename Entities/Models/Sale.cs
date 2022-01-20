using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("Number")]
        public string Number { get; set; }
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("LastChangeDate")]
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
        [JsonPropertyName("DiscountPercent")]
        public int DiscountPercent { get; set; }
        [JsonPropertyName("IsSupply")]
        public bool IsSupply { get; set; }
        [JsonPropertyName("IsRealization")]
        public bool IsRealization { get; set; }
        [JsonPropertyName("OrderId")]
        public int? OrderId { get; set; }
        [JsonPropertyName("PromoCodeDiscount")]
        public int PromoCodeDiscount { get; set; }
        [JsonPropertyName("WarehouseName")]
        public string WarehouseName { get; set; }
        [JsonPropertyName("CountryName")]
        public string CountryName { get; set; }
    }
}
