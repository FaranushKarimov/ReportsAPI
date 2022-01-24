using Contracts;
using RestSharp;
using System.Linq;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("ozon")]
    public class OzonApiController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ILoggerManager _logger;

        public OzonApiController(DataContext db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetTransaction")]
        public async Task<TransactionResult> GetTransactionsAsync(string from = "2021-11-01T00:00:00.000Z", string to = "2021-11-02T00:00:00.000Z", string transaction_type = "all")
        {
            from = "2021-11-01T00:00:00.000Z";
            to = "2021-11-02T00:00:00.000Z";

            var client = new RestClient("https://api-seller.ozon.ru/v3/finance/transaction/list");
            var request = new RestRequest("https://api-seller.ozon.ru/v3/finance/transaction/list", Method.Post);

            request.AddHeader("Client-Id", Credentials.CLIENT_ID);
            request.AddHeader("Api-Key", Credentials.API_KEY);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                filter = new
                {
                    date = new
                    {
                        from = from,
                        to = to
                    },
                    posting_number = "",
                    transaction_type = transaction_type
                },
                page = 1,
                page_size = 1000,
            });

            RestResponse response = await client.ExecuteAsync(request);

            var report = JsonConvert.DeserializeObject<TransactionResult>(response.Content);
            var ops = new List<Operation>();
            foreach (var op in report.Result.Operations)
            {
                // Don't duplicate
                bool is_present = _db.Operations.Any(x => x.operation_id == op.operation_id);
                if (!is_present)
                    ops.Add(op);
            }
            await _db.Operations.AddRangeAsync(ops);
            await _db.SaveChangesAsync();
            return report;
        }

        [HttpGet("getasa")]
        public IActionResult GetAsa()
        {
            var operations = _db.Operations.ToList();
            var items = _db.Items.ToList();
            var postings = _db.Postings.ToList();
            return Ok(operations);
        }

        [HttpGet("test")]
        public int Test()
        {
            return _db.Operations.Count();
        }

        [HttpGet("GetStocks")]
        public List<StockResults> GetStocks()
        {
            return new List<StockResults>();
        }

        // [HttpGet]
        // [Route("SaveTransactions")]
        // public async Task SaveTransactions() {
        //     var transactions = await GetTransactionsAsync();
        //     _db.TransactionResults.Add(transactions);
        // }
    }
}
