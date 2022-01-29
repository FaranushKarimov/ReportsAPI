using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ReportsAPI.Services
{
    public class UpdaterWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public UpdaterWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true) {
                Console.WriteLine("Started worker !");
                using var scope = _serviceProvider.CreateScope();
                var WbService = scope.ServiceProvider.GetRequiredService<IWbReportsService>();
                var OzonService = scope.ServiceProvider.GetRequiredService<IOzonReportsService>();
                // Update Wildberries
                await WbService.UpdateAll();
                // Update Ozon
                await OzonService.UpdateAll();

                Console.WriteLine("Enderd worker cycle !");
                await Task.Delay(TimeSpan.FromDays(1));
            }
        }
    }
}
