using Contracts;
using RestSharp;
using System.Linq;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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

        [HttpGet]
        [Route("GetTransaction")]
        public async Task<TransactionResult> GetTransactionsAsync(string from = "2021-11-01T00:00:00.000Z", string to = "2021-11-02T00:00:00.000Z", string transaction_type = "all")
        {
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
            return report;
        }

        [HttpPost]
        [Route("SaveTransaction")]
        public async Task<IActionResult> SaveTransaction() {
            var report = await GetTransactionsAsync();
            var ops = new List<Operation>();
            foreach (var op in report.Result.Operations)
            {
                // Don't duplicate
                // TODO: Make this faster
                bool is_present = _db.Operations.Any(x => x.operation_id == op.operation_id);
                if (!is_present)
                    ops.Add(op);
            }
            try {
                await _db.Operations.AddRangeAsync(ops);
                await _db.SaveChangesAsync();
            } catch(Exception ex) {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetStocks")]
        public async Task<StockResults> GetStocksAsync()
        {
            var client = new RestClient("https://api-seller.ozon.ru/v1/analytics/stock_on_warehouses");
            var request = new RestRequest("https://api-seller.ozon.ru/v1/analytics/stock_on_warehouses", Method.Post);

            request.AddHeader("Client-Id", Credentials.CLIENT_ID);
            request.AddHeader("Api-Key", Credentials.API_KEY);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                limit = 1000000,
                offset = 0
            });

            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.StatusCode);

            var report = JsonConvert.DeserializeObject<StockResults>(response.Content);

            return report;
        }
        [HttpPost]
        [Route("SaveStocks")]
        public async Task<IActionResult> SaveStocksAsync() {
            var report = await GetStocksAsync();

            try {
                await _db.StockResults.AddRangeAsync(report);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                await _db.SaveChangesAsync();
            }
            return Ok();
        }

        [HttpGet]
        [Route("GetPostings")]
        public async Task<PostingResult> GetPostings(string dir = "ASC",
            string since = "2021-09-01T00:00:00.000Z",
            string to = "2021-11-17T10:44:12.828Z",
            string status = "",
            int limit = 1000,
            int offset = 0,
            bool translit = true)
        {
            var client = new RestClient("https://api-seller.ozon.ru/v2/posting/fbo/list");
            var request = new RestRequest("https://api-seller.ozon.ru/v2/posting/fbo/list", Method.Post);

            request.AddHeader("Client-Id", Credentials.CLIENT_ID);
            request.AddHeader("Api-Key", Credentials.API_KEY);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(new
            {
                dir = "",
                filter = new {
                    since = since,
                    status = status,
                    to = to,
                },
                limit = limit,
                offset = offset,
                translit = translit,
                with = new {
                    analytics_data = true,
                    financial_data = true,
                },
            });

            RestResponse response = await client.ExecuteAsync(request);
            var report = JsonConvert.DeserializeObject<PostingResult>(response.Content);

            return report;
        }

        [HttpPost]
        [Route("SavePostings")]
        public async Task<IActionResult> SavePostings() {
            var report = await GetPostings();

            try {
                await _db.PostingResults.AddRangeAsync(report);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            } finally {
                await _db.SaveChangesAsync();
            }
            return Ok();
        }
    }
}
