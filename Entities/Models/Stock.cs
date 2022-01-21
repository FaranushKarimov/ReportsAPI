﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    [Table("Stocks")]
    public class Stock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [JsonPropertyName("Id")]
        public int Id { get; set; }
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
        [JsonPropertyName("IsSupply")]
        public int IsSupply { get; set; }
        [JsonPropertyName("IsRealisation")]
        public int IsRealisation { get; set; }
        [JsonPropertyName("QuantityFull")]
        public int QuantityFull { get; set; }
        [JsonPropertyName("QuantityNotInOrders")]
        public int QuantityNotInOrders { get; set; }
        [JsonPropertyName("WarehouseName")]
        public string WarehouseName { get; set; }
        [JsonPropertyName("InWayToClient")]
        public int InWayToClient { get; set; }
        [JsonPropertyName("InWayFromClient")]
        public int InWayFromClient { get; set; }
        [JsonPropertyName("NmId")]
        public Int64 NmId { get; set; }
    }
}
