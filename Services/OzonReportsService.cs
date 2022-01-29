using System;
using RestSharp;
using System.Net;
using System.Linq;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class OzonReportsService : IOzonReportsService
{
    private readonly DataContext _db;

    public OzonReportsService(DataContext db)
    {
        _db = db;
    }

    public async Task<PostingResults> GetPostingsAsync()
    {
        Console.WriteLine("Getting Ozon Postings...");
        // TODO: Refactor this
        string dir = "ASC";
        string since = (DateTime.Today.AddDays(-1).ToString("yyyy-MM-ddT00:00:00.000Z"));
        string to = (DateTime.Today.ToString("yyyy-MM-ddT00:00:00.000Z"));
        string status = "";
        int limit = 1000;
        int offset = 0;
        bool translit = true;


        const string BaseUrl = "https://api-seller.ozon.ru/v2/posting/fbo/list";
        var client = new RestClient(BaseUrl);
        var request = new RestRequest(BaseUrl, Method.Post);

        request.AddHeader("Client-Id", Credentials.CLIENT_ID);
        request.AddHeader("Api-Key", Credentials.API_KEY);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new
        {
            dir = dir,
            filter = new
            {
                since = since,
                status = status,
                to = to,
            },
            limit = limit,
            offset = offset,
            translit = translit,
            with = new
            {
                analytics_data = true,
                financial_data = true,
            },
        });

        RestResponse response = await client.ExecuteAsync(request);
        Console.WriteLine($"--\n{response.StatusCode}: {response.StatusDescription}\n{response.Content}\n");

        var report = JsonConvert.DeserializeObject<PostingResults>(response.Content);

        return report;
    }
    public async Task SavePostingsAsync(PostingResults results)
    {
        await _db.PostingResults.AddRangeAsync(results);
        await _db.SaveChangesAsync();
    }

    public async Task<StockResults> GetStocksAsync()
    {
        Console.WriteLine("Getting ozon stocks...");

        const string BaseUrl = "https://api-seller.ozon.ru/v1/analytics/stock_on_warehouses";
        var client = new RestClient(BaseUrl);
        var request = new RestRequest(BaseUrl, Method.Post);

        request.AddHeader("Client-Id", Credentials.CLIENT_ID);
        request.AddHeader("Api-Key", Credentials.API_KEY);
        request.AddHeader("Content-Type", "application/json");

        const int limit = 1000000;
        const int offset = 0;
        request.AddJsonBody(new
        {
            limit = limit,
            offset = offset
        });

        RestResponse response = await client.ExecuteAsync(request);

        Console.WriteLine($"{response.StatusCode}: {response.StatusDescription}");

        var report = JsonConvert.DeserializeObject<StockResults>(response.Content);
        return report;
    }
    public async Task SaveStocksAsync(StockResults result)
    {
        await _db.StockResults.AddRangeAsync(result);
        await _db.SaveChangesAsync();
    }

    public async Task<TransactionResult> GetTransactionsAsync()
    {
        Console.WriteLine("Getting Ozon transactions ...");
        const string Resource = "https://api-seller.ozon.ru/v3/finance/transaction/list";
        var client = new RestClient(Resource);
        var request = new RestRequest(Resource, Method.Post);

        request.AddHeader("Client-Id", Credentials.CLIENT_ID);
        request.AddHeader("Api-Key", Credentials.API_KEY);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new
        {
            filter = new
            {
                date = new
                {
                    from = (DateTime.Today.AddDays(-15).ToString("yyyy-MM-ddT00:00:00.000Z")),
                    to = (DateTime.Today.ToString("yyyy-MM-ddT00:00:00.000Z"))
                },
                posting_number = "",
                transaction_type = "all"
            },
            page = 1,
            page_size = 1000,
        });

        RestResponse response = await client.ExecuteAsync(request);

        Console.WriteLine($"--\n{response.StatusCode}: {response.StatusDescription}\n{response.Content}\n");

        var report = JsonConvert.DeserializeObject<TransactionResult>(response.Content);
        return report;

    }
    public async Task SaveTransactionAsync(TransactionResult report)
    {
        var ops = new List<Operation>();
        foreach (var op in report.Result.Operations)
        {
            // Don't duplicate
            // TODO: Make this faster
            bool is_present = _db.Operations.Any(x => x.operation_id == op.operation_id);
            if (!is_present)
                ops.Add(op);
        }
        await _db.Operations.AddRangeAsync(ops);
        await _db.SaveChangesAsync();
    }

    public async Task SaveAll()
    {
        Console.WriteLine("Started Ozon global update");
        await SaveTransactionAsync(await GetTransactionsAsync());
        await SavePostingsAsync(await GetPostingsAsync());
        await SaveStocksAsync(await GetStocksAsync());
        Console.WriteLine("Ended Ozon global update");
    }

    public async Task UpdateAll()
    {
        await SaveAll();
    }
}
