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
    }
}
