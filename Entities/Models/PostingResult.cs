using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Action
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string action { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    public class Product
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public int sku { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string offer_id { get; set; }
        public string price { get; set; }
        //public List<object> digital_codes { get; set; }
        public decimal commission_amount { get; set; }
        public decimal commission_percent { get; set; }
        public decimal payout { get; set; }
        public int product_id { get; set; }
        public decimal old_price { get; set; }
        public decimal total_discount_value { get; set; }
        public decimal total_discount_percent { get; set; }
        //public List<Action> actions { get; set; }
        // public object picking { get; set; }
        public decimal? client_price { get; set; }
        public ItemServices item_services { get; set; }
    }

    public class AnalyticsData
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public string region { get; set; }
        public string city { get; set; }
        public string delivery_type { get; set; }
        public bool is_premium { get; set; }
        public string payment_type_group_name { get; set; }
        public string warehouse_id { get; set; }
        public string warehouse_name { get; set; }
        public bool is_legal { get; set; }
    }

    public class ItemServices
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public decimal marketplace_service_item_fulfillment { get; set; }
        public decimal marketplace_service_item_pickup { get; set; }
        public decimal marketplace_service_item_dropoff_pvz { get; set; }
        public decimal marketplace_service_item_dropoff_sc { get; set; }
        public decimal marketplace_service_item_dropoff_ff { get; set; }
        public decimal marketplace_service_item_direct_flow_trans { get; set; }
        public decimal marketplace_service_item_return_flow_trans { get; set; }
        public decimal marketplace_service_item_deliv_to_customer { get; set; }
        public decimal marketplace_service_item_return_not_deliv_to_customer { get; set; }
        public decimal marketplace_service_item_return_part_goods_customer { get; set; }
        public decimal marketplace_service_item_return_after_deliv_to_customer { get; set; }
    }

    public class PostingServices
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public decimal marketplace_service_item_fulfillment { get; set; }
        public decimal marketplace_service_item_pickup { get; set; }
        public decimal marketplace_service_item_dropoff_pvz { get; set; }
        public decimal marketplace_service_item_dropoff_sc { get; set; }
        public decimal marketplace_service_item_dropoff_ff { get; set; }
        public decimal marketplace_service_item_direct_flow_trans { get; set; }
        public decimal marketplace_service_item_return_flow_trans { get; set; }
        public decimal marketplace_service_item_deliv_to_customer { get; set; }
        public decimal marketplace_service_item_return_not_deliv_to_customer { get; set; }
        public decimal marketplace_service_item_return_part_goods_customer { get; set; }
        public decimal marketplace_service_item_return_after_deliv_to_customer { get; set; }
    }

    public class FinancialData
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public List<Product> products { get; set; }
        public PostingServices posting_services { get; set; }
    }

    public class PostingResultResult
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public int order_id { get; set; }
        public string order_number { get; set; }
        public string posting_number { get; set; }
        public string status { get; set; }
        public int cancel_reason_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime in_process_at { get; set; }
        public List<Product> products { get; set; }
        public AnalyticsData analytics_data { get; set; }
        public FinancialData financial_data { get; set; }
        //public List<object> additional_data { get; set; }
    }

    public class PostingResult
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        public List<PostingResultResult> result { get; set; }
    }
}
