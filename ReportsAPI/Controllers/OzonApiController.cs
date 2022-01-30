using Entities.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ReportsAPI.Controllers
{
    [ApiController]
    [Route("ozon")]
    public class OzonApiController : ControllerBase
    {
        private readonly ILogger<OzonApiController> _logger;
        private readonly IOzonReportsService _ozonService;

        public OzonApiController(ILogger<OzonApiController> logger, IOzonReportsService ozonService)
        {
            _logger = logger;
            _ozonService = ozonService;
        }

        [HttpGet]
        [Route("GetTransaction")]
        public async Task<TransactionResult> GetTransactionsAsync(string from = "2021-11-01T00:00:00.000Z", string to = "2021-11-02T00:00:00.000Z", string transaction_type = "all")
        {
            //Console.WriteLine(await _ozonService.GetTransactionsAsync());
            var result = await _ozonService.GetTransactionsAsync();
            return result;
        }

        [HttpPost]
        [Route("SaveTransaction")]
        public async Task<IActionResult> SaveTransaction()
        {
            var result = await _ozonService.GetTransactionsAsync();
            await _ozonService.SaveTransactionAsync(result);
            return Ok();
        }

        [HttpGet]
        [Route("GetStocks")]
        public async Task<StockResults> GetStocksAsync()
        {
            var result = await _ozonService.GetStocksAsync();
            return result;
        }

        [HttpPost]
        [Route("SaveStocks")]
        public async Task<IActionResult> SaveStocksAsync()
        {
            var result = await _ozonService.GetStocksAsync();
            await _ozonService.SaveStocksAsync(result);
            return Ok();
        }

        [HttpGet]
        [Route("GetPostings")]
        public async Task<PostingResults> GetPostings()
        {
            return await _ozonService.GetPostingsAsync();
        }

        [HttpPost]
        [Route("SavePostings")]
        public async Task<IActionResult> SavePostings()
        {
            var results = await _ozonService.GetPostingsAsync();
            await _ozonService.SavePostingsAsync(results);
            return Ok();
        }
        [HttpGet]
        [Route("GetSpecificPosting")]
        public PostingResultResult GetSpecificPosting(string id)
        {
            return _ozonService.GetPosting(id);
        }
        [HttpPost]
        [Route("SaveSpecificPosting")]
        public async Task SavePosting(string id) {
            await _ozonService.SavePostingAsync(id);
        }

        [HttpPost]
        [Route("SaveAll")]
        public async Task SaveAllAsync()
        {
            await SaveTransaction();
            await SaveStocksAsync();
        }
    }
}
