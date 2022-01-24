using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Stock
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public int not_for_sale { get; set; }
        public int loss { get; set; }
        public int for_sale { get; set; }
        public int between_warehouses { get; set; }
        public int shipped { get; set; }
    }

    public class StockItem
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string offer_id { get; set; }
        public int sku { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string discounted { get; set; }
        public string barcode { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double volume { get; set; }
        public int weight { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }
        public Stock stock { get; set; }
    }

    public class WhItem
    {
        [Key]
        public string id { get; set; }

        public string name { get; set; }
        public List<StockItem> items { get; set; }

        [ForeignKey("StockResults")]
        public int StockResultsId { get; set; }
        public StockResults StockResults { get; set; }
    }

    public class TotalItem
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string offer_id { get; set; }
        public int sku { get; set; }
        public string title { get; set; }
        public string category { get; set; }
        public string discounted { get; set; }
        public string barcode { get; set; }
        public double length { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double volume { get; set; }
        public int weight { get; set; }

        [ForeignKey("Stock")]
        public int StockId { get; set; }
        public Stock Stock { get; set; }

        [ForeignKey("StockResults")]
        public int StockResultsId { get; set; }
        public StockResults StockResults { get; set; }
    }

    public class StockResults
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public List<WhItem> wh_items { get; set; }
        public List<TotalItem> total_items { get; set; }
        public string timestamp { get; set; }
    }
}
