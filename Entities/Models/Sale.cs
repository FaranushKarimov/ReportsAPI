using System;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public decimal TotalPrice { get; set; }
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
        [JsonPropertyName("oblastOkrugName")]
        public string oblastOkrugName { get; set; }
        [JsonPropertyName("regionName")]
        public string regionName { get; set; }
        [JsonPropertyName("incomeID")]
        public int incomeID { get; set; }
        [JsonPropertyName("saleID")]
        public int saleID { get; set; }
        [JsonPropertyName("odid")]
        public int odid { get; set; }
        [JsonPropertyName("spp")]
        public int spp { get; set; }
        [JsonPropertyName("forPay")]
        public decimal forPay { get; set; }
        [JsonPropertyName("finishedPrice")]
        public decimal finishedPrice { get; set; }
        [JsonPropertyName("priceWithDisc")]
        public decimal priceWithDisc { get; set; }
        [JsonPropertyName("nmId")]
        public int nmId { get; set; }
        [JsonPropertyName("subject")]
        public string subject { get; set; }
        [JsonPropertyName("category")]
        public string category { get; set; }
        [JsonPropertyName("brand")]
        public string brand { get; set; }
        [JsonPropertyName("IsStorno")]
        public bool IsStorno { get; set; }
        [JsonPropertyName("gNumber")]
        public string gNumber { get; set; }
    }
}
