using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public class Product
    {
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
        public List<string> actions { get; set; }
        // public object picking { get; set; }
        public decimal? client_price { get; set; }
        public ItemServices item_services { get; set; }
    }

    public class AnalyticsData
    {
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
        public List<Product> products { get; set; }
        public PostingServices posting_services { get; set; }
    }

    public class PostingResultResult
    {
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
        public List<PostingResultResult> result { get; set; }
    }
}
