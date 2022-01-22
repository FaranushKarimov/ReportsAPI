using Contracts;
using RestSharp;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("ozon")]
    public class OzonApiController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ILoggerManager _logger;
        private const string key = "ODBhODE5NTYtODFjZC00MDc3LWIxMzEtMDgyNjRjMDEzNTVl";
        private const int client_id = 43445;

        public OzonApiController(DataContext db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpPost]
        [Route("GetTransaction")]
        public async Task<TransactionResult> GetTransactionsAsync(string from = "2021-11-01T00:00:00.000Z" , string to = "2021-11-02T00:00:00.000Z", string transaction_type = "all")
        {
            from = "2021-11-01T00:00:00.000Z";
            to = "2021-11-02T00:00:00.000Z";

            var client = new RestClient("https://api-seller.ozon.ru/v3/finance/transaction/list");
            var request = new RestRequest("https://api-seller.ozon.ru/v3/finance/transaction/list", Method.Post);
            request.AddHeader("Client-Id", "43445");
            request.AddHeader("Api-Key", "6ca743d9-3441-47fb-b4ce-d7b531fbb31b");
            request.AddHeader("Content-Type", "application/json");

            request.AddJsonBody(new
            {
                filter = new {
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
            return report;
        }

        // [HttpGet]
        // [Route("SaveTransactions")]
        // public async Task SaveTransactions() {
        //     var transactions = await GetTransactionsAsync();
        //     _db.TransactionResults.Add(transactions);
        // }
    }
}
