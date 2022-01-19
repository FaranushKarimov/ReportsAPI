using RestSharp;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Entities.Models;
using System.Collections.Generic;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        [HttpGet]
        [Route("GetStock")]
        /* Get list of stocks and deserialize them. */
        public async Task<List<Stock>> GetStockAsync(string date = "2017-03-25T21%3A00%3A00.000Z", string key = "YzEyY2Y2MWMtYjViNC00MTM4LWIzZDEtYmUxOWNhMjc3NDA0") {
            var client = new RestClient($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={key}");
            var request = new RestRequest($"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={key}", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            var stock = JsonConvert.DeserializeObject<List<Stock>>(response.Content);

            return stock;
        }
    }
}
