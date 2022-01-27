using Contracts.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
                await Task.Delay(TimeSpan.FromDays(1));
                using var scope = _serviceProvider.CreateScope();
                var incomeService = scope.ServiceProvider.GetRequiredService<IIncomeService>();
                await incomeService.UpdateAsync();
            }
        }
    }
}
