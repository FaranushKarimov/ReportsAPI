using RestSharp;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly DataContext _db;

        public ApiController(DataContext db)
        {
            _db = db;
        }
        
        
        /* Get list of stocks and deserialize them. */
        public async Task<List<Incomes>> GetStockAsync(string date = "2017-03-25T21%3A00%3A00.000Z", string key = "YzEyY2Y2MWMtYjViNC00MTM4LWIzZDEtYmUxOWNhMjc3NDA0") {
            var client = new RestClient($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={key}");
            var request = new RestRequest($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={key}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var stock = JsonConvert.DeserializeObject<List<Incomes>>(response.Content);

            return stock;
        }

        public async Task<List<ReportDetailByPeriod>> GetRep(
            string key = "YzEyY2Y2MWMtYjViNC00MTM4LWIzZDEtYmUxOWNhMjc3NDA0", string datefrom = "2022-01-01",
            string dateto = "2022-01-20")
        {
            var client =
                new RestClient(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={key}&datefrom={datefrom}&dateto={dateto}");
            var request =
                new RestRequest(
                    $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={key}&datefrom={datefrom}&dateto={dateto}",
                    Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var report = JsonConvert.DeserializeObject<List<ReportDetailByPeriod>>(response.Content);

            return report;
        }

        [HttpGet]
        [Route("SaveStocks")]
        /* Save the stocks to the database */
        public async Task SaveStocks() {
            var stocks = await GetStockAsync();

            foreach (var stock in stocks) {
                _db.Stocks.Add(stock);
            }

            await _db.SaveChangesAsync();
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
