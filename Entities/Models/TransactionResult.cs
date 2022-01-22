using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    
    public class Posting
    {
        public int Id { get; set; }
        public string delivery_schema { get; set; }
        public string order_date { get; set; }
        public string posting_number { get; set; }
        public long warehouse_id { get; set; }

        public ICollection<Operation> Operations { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public int OperationId { get; set; }
        public string name { get; set; }
        public int sku { get; set; }
        [ForeignKey("OperationId")]
        public Operation Operation { get; set; }
    }

    public class Operation
    {
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
        public Posting posting { get; set; }
        public List<Item> items { get; set; }
        //public List<object> services { get; set; }
    }

    public class Result
    {
        public List<Operation> operations { get; set; }
        public long page_count { get; set; }
        public long row_count { get; set; }
    }

    public class TransactionResult
    {
        public Result result { get; set; }
    }

}
