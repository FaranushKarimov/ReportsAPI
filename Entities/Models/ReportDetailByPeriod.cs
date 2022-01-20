using System;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class ReportDetailByPeriod
    {
        [JsonPropertyName("id")]
        public int id { get; set; }
        [JsonPropertyName("realizationreport_id")]
        public int realizationreport_id { get; set; }
        [JsonPropertyName("suppliercontract_code")]
        public string suppliercontract_code { get; set; }
        [JsonPropertyName("rrd_id")]
        public Int64 rrd_id { get; set; }
        [JsonPropertyName("gi_id")]
        public int gi_id { get; set; }
        [JsonPropertyName("subject_name")]
        public string subject_name { get; set; }
        [JsonPropertyName("nm_id")]
        public int nm_id { get; set; }
        [JsonPropertyName("brand_name")]
        public string brand_name { get; set; }
        [JsonPropertyName("sa_name")]
        public string sa_name { get; set; }
        [JsonPropertyName("ts_name")]
        public string ts_name { get; set; }
        [JsonPropertyName("barcode")]
        public string barcode { get; set; }
        [JsonPropertyName("doc_type_name")]
        public string doc_type_name { get; set; }
        [JsonPropertyName("quantity")]
        public int quantity { get; set; }
        [JsonPropertyName("retail_price")]
        public int retail_price { get; set; }
        [JsonPropertyName("retail_amount")]
        public double retail_amount { get; set; }
        [JsonPropertyName("sale_percent")]
        public double sale_percent { get; set; }
        [JsonPropertyName("commission_percent")]
        public double commission_percent { get; set; }
        [JsonPropertyName("office_name")]
        public string office_name { get; set; }
        [JsonPropertyName("supplier_oper_name")]
        public string supplier_oper_name { get; set; }
        [JsonPropertyName("order_dt")]
        public  DateTime order_dt { get; set; }
        [JsonPropertyName("sale_dt")]
        public DateTime sale_dt { get; set; }
        [JsonPropertyName("rr_dt")]
        public DateTime rr_dt { get; set; }
        [JsonPropertyName("shk_id")]
        public Int64 shk_id { get; set; }
        [JsonPropertyName("retail_price_withdisc_rub")]
        public double retail_price_withdisc_rub { get; set; }
        [JsonPropertyName("delivery_amount")]
        public int delivery_amount { get; set; }
        [JsonPropertyName("return_amount")]
        public int return_amount { get; set; }
        [JsonPropertyName("delivery_rub")]
        public int delivery_rub { get; set; }
        [JsonPropertyName("gi_box_type_name")]
        public string gi_box_type_name { get; set; }
        [JsonPropertyName("product_discount_for_report")]
        public int product_discount_for_report { get; set; }
        [JsonPropertyName("supplier_promo")]
        public int supplier_promo { get; set; }
        [JsonPropertyName("rid")]
        public Int64 rid { get; set; }
        [JsonPropertyName("ppvz_reward")]
        public double ppvz_reward { get; set; }
        [JsonPropertyName("ppvz_vw")]
        public double ppvz_vw { get; set; }
        [JsonPropertyName("ppvz_vw_nds")]
        public double ppvz_vw_nds { get; set; }
        [JsonPropertyName("ppvz_office_id")]
        public double ppvz_office_id { get; set; }
        [JsonPropertyName("ppvz_office_name")]
        public string ppvz_office_name { get; set; }
        [JsonPropertyName("ppvz_supplier_id")]
        public int ppvz_supplier_id { get; set; }
    }
}