using System;
using RestSharp;
using System.Net;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

public class OzonReportsService : IOzonReportsService
{
    private readonly DataContext _db;

    public async Task<PostingResults> GetPostingsAsync()
    {
        // TODO: Refactor this
        string dir = "ASC";
        string since = "2021-09-01T00:00:00.000Z";
        string to = "2021-11-17T10:44:12.828Z";
        string status = "";
        int limit = 1000;
        int offset = 0;
        bool translit = true;


        var client = new RestClient("https://api-seller.ozon.ru/v2/posting/fbo/list");
        var request = new RestRequest("https://api-seller.ozon.ru/v2/posting/fbo/list", Method.Post);

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
        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(response.StatusDescription);
        }
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
        var client = new RestClient("https://api-seller.ozon.ru/v1/analytics/stock_on_warehouses");
        var request = new RestRequest("https://api-seller.ozon.ru/v1/analytics/stock_on_warehouses", Method.Post);

        request.AddHeader("Client-Id", Credentials.CLIENT_ID);
        request.AddHeader("Api-Key", Credentials.API_KEY);
        request.AddHeader("Content-Type", "application/json");

        request.AddJsonBody(new
        {
            limit = 1000000,
            offset = 0
        });

        RestResponse response = await client.ExecuteAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(response.StatusDescription);
        }

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
        var client = new RestClient("https://api-seller.ozon.ru/v3/finance/transaction/list");
        var request = new RestRequest("https://api-seller.ozon.ru/v3/finance/transaction/list", Method.Post);

        request.AddHeader("Client-Id", Credentials.CLIENT_ID);
        request.AddHeader("Api-Key", Credentials.API_KEY);
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(new
        {
            filter = new
            {
                date = new
                {
                    from = Uri.EscapeDataString((DateTime.Today.AddDays(-15).ToString("yyyy-MM-ddT00:00:00.000Z"))),
                    to = Uri.EscapeDataString((DateTime.Today.ToString("yyyy-MM-ddT00:00:00.000Z")))
                },
                posting_number = "",
                transaction_type = "all"
            },
            page = 1,
            page_size = 1000,
        });

        RestResponse response = await client.ExecuteAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(response.StatusDescription + "\n" + response.ErrorMessage);
        }

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

    public Task SaveAll()
    {
        throw new System.NotImplementedException();
    }




    public Task UpdateAll()
    {
        throw new System.NotImplementedException();
    }
}
