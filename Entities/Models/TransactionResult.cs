using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Entities.Models
{
    
    public class Posting
    {
        [Key]
        public int Id { get; set; }

        public string delivery_schema { get; set; }
        public string order_date { get; set; }
        public string posting_number { get; set; }
        public long warehouse_id { get; set; }

        [JsonIgnore]
        public ICollection<Operation> Operations { get; set; }
    }

    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string name { get; set; }
        public int sku { get; set; }
    }

    public class Operation
    {
        [Key]
        public int Id { get; set; }

        public long operation_id { get; set; }
        public string operation_type { get; set; }
        public string operation_date { get; set; }
        public string operation_type_name { get; set; }
        public decimal delivery_charge { get; set; }
        public decimal return_delivery_charge { get; set; }
        public decimal accruals_for_sale { get; set; }
        public decimal sale_commission { get; set; }
        public decimal amount { get; set; }
        public string type { get; set; }

        public int PostingId { get; set; }
        [ForeignKey("PostingId")]
        public Posting Posting { get; set; }
        public List<Item> items { get; set; }
        //public List<object> services { get; set; }
    }

    public class Result
    {
        public List<Operation> Operations { get; set; }
        public long Page_count { get; set; }
        public long Row_count { get; set; }
    }

    public class TransactionResult
    {
        public Result Result { get; set; }
    }

}
