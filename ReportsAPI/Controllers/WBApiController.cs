using System;
using Contracts;
using RestSharp;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly ILoggerManager _logger;

        public ApiController(DataContext db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }


        /* Get list of stocks and deserialize them. */
        [HttpGet]
        [Route("GetStocks")]
        public async Task<List<Income>> GetStockAsync()
        {

            var date = Uri.EscapeDataString((DateTime.Now.AddDays(-100).ToString("yyyy-MM-ddTHH:ss:00.000Z")));
            //var date = "2021-03-25T21%3A00%3A00.000Z";

            _logger.LogError(date);
            var client = new RestClient($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={Credentials.WB_API_KEY}");
            var request = new RestRequest($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={Credentials.WB_API_KEY}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var stock = JsonConvert.DeserializeObject<List<Income>>(response.Content);

            return stock;
        }

        [HttpGet]
        [Route("GetRep")]
        public async Task<List<ReportDetailByPeriod>> GetRep([FromRoute] string datefrom = "2022-01-01", [FromRoute] string dateto = "2022-01-20")
        {
            var client =
                new RestClient(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={Credentials.WB_API_KEY}&datefrom={datefrom}&dateto={dateto}");
            var request =
                new RestRequest(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={Credentials.WB_API_KEY}&datefrom={datefrom}&dateto={dateto}",
                    Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var report = JsonConvert.DeserializeObject<List<ReportDetailByPeriod>>(response.Content);

            return report;
        }

        [HttpGet]
        [Route("SaveIncomes")]
        /* Save the stocks to the database */
        public async Task SaveIncomes()
        {
            var stocks = await GetStockAsync();

            foreach (var stock in stocks)
            {
                _db.Incomes.Add(stock);
            }

            await _db.SaveChangesAsync();
        }

        [HttpGet]
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
        [Route("GetSales")]
        public async Task<List<Sale>> GetSalesAsync()
        {
            //var datefrom = Uri.EscapeDataString((DateTime.Now.ToString("yyyy-MM-ddTHH:ss:00.000Z")));
            var datefrom = "2022-01-01T21:00:00.000Zl";

            var client =
                new RestClient(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/sales?dateFrom={datefrom}&key={Credentials.WB_API_KEY}");
            var request =
                new RestRequest(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/sales?dateFrom={datefrom}&key={Credentials.WB_API_KEY}",
                    Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var report = JsonConvert.DeserializeObject<List<Sale>>(response.Content);

            return report;

        }

        [HttpGet]
        [Route("GetReports")]
        public async Task GetReports()
        {
            var reports = await GetRep();

            foreach (var report in reports)
            {
                _db.ReportDetailByPeriods.Add(report);
                
            }

            await _db.SaveChangesAsync();
        }
    }
}
