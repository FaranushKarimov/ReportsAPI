using System;
using Contracts;
using RestSharp;
using System.Net;
using Entities.Models;
using Newtonsoft.Json;
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
        private readonly IWbReportsService _service;

        public WildberriesApiController(DataContext db, ILoggerManager logger, IWbReportsService service)
        {
            _db = db;
            _logger = logger;
            _service = service;
        }

        /* Get list of stocks and deserialize them. */
        [HttpGet]
        [Route("GetIncomes")]
        public async Task<List<Income>> GetIncomesAsync()
        {
            return await _service.GetIncomesAsync();
        }

        [HttpPost]
        [Route("SaveIncomes")]
        /* Save the stocks to the database */
        public async Task SaveIncomes()
        {
            var result = await _service.GetIncomesAsync();
            await _service.SaveIncomesAsync(result);
        }


        [HttpGet]
        [Route("GetSales")]
        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _service.GetSalesAsync();
        }

        [HttpPost]
        [Route("SaveSales")]
        /* Save the stocks to the database */
        public async Task SaveSales()
        {
            var result = await _service.GetSalesAsync();
            await _service.SaveSalesAsync(result);
        }

        [HttpGet]
        [Route("GetReports")]
        public async Task<List<ReportDetailByPeriod>> GetReports()
        {
            return await _service.GetReportsAsync();
        }

        [HttpPost]
        [Route("SaveReports")]
        public async Task SaveReports()
        {
            var result = await _service.GetReportsAsync();
            await _service.SaveReportsAsync(result);
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<List<OrderResult>> GetOrdersAsync()
        {
            return await _service.GetOrdersAsync();
        }

        [HttpPost]
        [Route("SaveOrders")]
        public async Task SaveOrders()
        {
            var result = await _service.GetOrdersAsync();
            await _service.SaveOrdersAsync(result);
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
