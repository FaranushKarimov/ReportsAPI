using System.Threading.Tasks;
using Contracts;
using Entities.DataContexts;
using Microsoft.AspNetCore.Mvc;
using ReportsAPI.Controllers;

namespace ReportsAPI.Controllers {
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase {
        private readonly DataContext _db;
        private readonly ILoggerManager _logger;

        public ApiController(DataContext db, ILoggerManager logger)
        {
            _db = db;
            _logger = logger;
        }

        // [HttpPost]
        // [Route("SaveAll")]
        // public async Task<IActionResult> SaveAll() {
        //
        // }
    }
}
