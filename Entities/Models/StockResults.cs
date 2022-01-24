using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models {
    public class OzonStockReport
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        [JsonPropertyName("not_for_sale")]
        public int NotForSale { get; set; }

        [JsonPropertyName("loss")]
        public int Loss { get; set; }

        [JsonPropertyName("for_sale")] public int ForSale { get; set; }

        [JsonPropertyName("between_warehouses")]
        public int BetweenWarehouses { get; set; }

        [JsonPropertyName("shipped")]
        public int Shipped { get; set; }
    }

    public class OzonItemReport
    {
        [Key]
        [JsonIgnore]
        public long Id { get; set; }

        [JsonPropertyName("offer_id")]
        public string Offer_id { get; set; }

        [JsonPropertyName("sku")]
        public int Sku { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("discounted")]
        public string Discounted { get; set; }

        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("length")]
        public double Length { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [ForeignKey("Stock")]
        public int OzonStockReportId { get; set; }
        [JsonPropertyName("stock")]
        public OzonStockReport Stock { get; set; }
    }

    public class WhItem
    {
        [Key]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("items")]
        public ICollection<OzonItemReport> Items { get; set; }

        [ForeignKey("StockResults")]
        public int StockResultsId { get; set; }
        public OzonStockReport StockResults { get; set; }
    }

    public class TotalItem
    {
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("offer_id")]
        public int OfferId { get; set; }

        [JsonPropertyName("sku")]
        public int Sku { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("discounted")]
        public string Discounted { get; set; }

        [JsonPropertyName("barcode")]
        public string Barcode { get; set; }

        [JsonPropertyName("length")]
        public double Length { get; set; }

        [JsonPropertyName("width")]
        public double Width { get; set; }

        [JsonPropertyName("height")]
        public double Height { get; set; }

        [JsonPropertyName("volume")]
        public double Volume { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("stock")]
        public OzonStockReport Stock { get; set; }

        [ForeignKey("StockResults")]
        public long StockResultsId { get; set; }
        public StockResults StockResults { get; set; }
    }

    public class StockResults
    {
        [Key]
        [JsonIgnore]
        public long Id { get; set; }

        [JsonPropertyName("wh_items")]
        public ICollection<WhItem> WhItems { get; set; }

        [JsonPropertyName("total_items")]
        public ICollection<TotalItem> TotalItems { get; set; }

        [JsonPropertyName("timestamp")]
        public string Timestamp { get; set; }
    }
}
