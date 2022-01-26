using System;
using Contracts;
using RestSharp;
using System.Net;
using Entities.Models;
using Newtonsoft.Json;
using ReportsAPI.Models;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("Wildberries")]
    public class WildberriesApiController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ILoggerManager _logger;

        public WildberriesApiController(DataContext db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }

        /* Get list of stocks and deserialize them. */
        [HttpGet]
        [Route("GetIncomes")]
        public async Task<List<Income>> GetIncomesAsync()
        {
            var date = Uri.EscapeDataString((DateTime.Now.ToString("yyyy-MM-ddT00:00:00.000Z")));

            var client = new RestClient($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={Credentials.WB_API_KEY}");
            var request = new RestRequest($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={Credentials.WB_API_KEY}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var stock = JsonConvert.DeserializeObject<List<Income>>(response.Content);

            return stock;
        }

        [HttpPost]
        [Route("SaveIncomes")]
        /* Save the stocks to the database */
        public async Task SaveIncomes()
        {
            var stocks = await GetIncomesAsync();

            await _db.Incomes.AddRangeAsync(stocks);

            await _db.SaveChangesAsync();
        }


        [HttpGet]
        [Route("GetSales")]
        public async Task<List<Sale>> GetSalesAsync()
        {
            //var datefrom = Uri.EscapeDataString((DateTime.Now.ToString("yyyy-MM-ddTHH:ss:00.000Z")));
            var datefrom = "2022-01-01T21:00:00.000Zl";

            var client = new RestClient( $"https://suppliers-stats.wildberries.ru/api/v1/supplier/sales?dateFrom={datefrom}&key={Credentials.WB_API_KEY}");
            var request = new RestRequest( $"https://suppliers-stats.wildberries.ru/api/v1/supplier/sales?dateFrom={datefrom}&key={Credentials.WB_API_KEY}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);
            if (true) {
                Console.WriteLine("ERROR: " + response.StatusDescription);
            }

            var report = JsonConvert.DeserializeObject<List<Sale>>(response.Content);

            return report;

        }

        [HttpPost]
        [Route("SaveSales")]
        /* Save the stocks to the database */
        public async Task SaveSales()
        {
            var sales = await GetSalesAsync();

            foreach (var sale in sales)
            {
                _db.Sales.Add(sale);
            }

            await _db.SaveChangesAsync();
        }

        [HttpGet]
        [Route("GetReports")]
        public async Task<List<ReportDetailByPeriod>> GetReports([FromRoute] string datefrom = "2022-01-01", [FromRoute] string dateto = "2022-01-20")
        {
            var client =
                new RestClient(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={Credentials.WB_API_KEY}&datefrom={datefrom}&dateto={dateto}");
            var request =
                new RestRequest(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={Credentials.WB_API_KEY}&datefrom={datefrom}&dateto={dateto}",
                    Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                Console.WriteLine("ERROR: " + response.StatusDescription);
            }

            var report = JsonConvert.DeserializeObject<List<ReportDetailByPeriod>>(response.Content);

            return report;
        }

        [HttpPost]
        [Route("SaveReports")]
        public async Task SaveReports()
        {
            var reports = await GetReports();

            foreach (var report in reports)
            {
                _db.ReportDetailByPeriods.Add(report);
            }

            await _db.SaveChangesAsync();
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<OrderResult>> GetOrdersAsync(string date = "2017-03-25T21:00:00.000Z")
        {
            date = Uri.EscapeDataString((DateTime.Now.ToString("yyyy-MM-ddT00:00:00.000Z")));

            var client =
                new RestClient(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/orders?dateFrom={date}&flag=0&key={Credentials.WB_API_KEY}");
            var request =
                new RestRequest(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/orders?dateFrom={date}&flag=0&key={Credentials.WB_API_KEY}",
                    Method.Get);
            request.Timeout = 1000000;
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode != HttpStatusCode.OK) {
                Console.WriteLine("ERROR: " + response.StatusDescription);
            }

            var report = JsonConvert.DeserializeObject<List<OrderResult>>(response.Content);

            return report;
        }

        [HttpPost]
        [Route("SaveOrders")]
        public async Task SaveOrders()
        {
            var reports = await GetOrdersAsync();

            foreach (var report in reports)
            {
                _db.WBOrders.Add(report);
            }

            await _db.SaveChangesAsync();
        }

        [HttpPost]
        [Route("SaveAll")]
        public async Task SaveAllAsync()
        {
            await SaveIncomes();
            await SaveSales();
            await SaveReports();
            await SaveOrders();
        }
    }
}
