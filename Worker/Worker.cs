using System;
using RestSharp;

namespace ReportsAPI.Worker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    private async Task FetchOzonAsync()
    {
        var client = new RestClient("https://localhost:5001/ozon/GetTransaction");
        var request = new RestRequest("https://localhost:5001/ozon/GetTransaction", Method.Get);
        client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        RestResponse response = await client.ExecuteAsync(request);

        Console.WriteLine(response.ErrorException);
    }

    private void FetchWb()
    {

    }

    private async Task FetchDataAsync()
    {
        await FetchOzonAsync();
        FetchWb();
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // while (!stoppingToken.IsCancellationRequested)
        // {
            _logger.Log(LogLevel.Information, "Starting data fethching from Wildberries");
            await FetchDataAsync();
            await Task.Delay(1000 * 5);
        // }
    }
}
