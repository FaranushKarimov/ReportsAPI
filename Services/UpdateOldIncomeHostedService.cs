using System;
using System.Threading;
using Contracts.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Services
{
    public class UpdateOldIncomeHostedService: BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        public UpdateOldIncomeHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromSeconds(1));
                using var scope = _serviceProvider.CreateScope();
                var incomeService = scope.ServiceProvider.GetRequiredService<IIncomeService>();

                await incomeService.UpdateAsync();
            }
        }
    }
}
