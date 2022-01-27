using System;
using RestSharp;
using System.Net;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

public class OzonReportsService : IOzonReportsService
{
    private readonly DataContext _db;

    public async Task GetPostings()
    {
        throw new System.NotImplementedException();
    }

    public Task GetStocks()
    {
        throw new System.NotImplementedException();
    }

    public Task GetTransaction()
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
                    from = from,
                    to = to
                },
                posting_number = "",
                transaction_type = transaction_type
            },
            page = 1,
            page_size = 1000,
        });

        RestResponse response = await client.ExecuteAsync(request);

        if (response.StatusCode != HttpStatusCode.OK)
        {
            throw new Exception(response.StatusDescription);
        }

        _logger.LogCritical("GetTransaction:" + response.StatusDescription);

        var report = JsonConvert.DeserializeObject<TransactionResult>(response.Content);
        return report;

    }

    public Task SaveAll()
    {
        throw new System.NotImplementedException();
    }

    public Task SavePostings()
    {
        throw new System.NotImplementedException();
    }

    public Task SaveStocks()
    {
        throw new System.NotImplementedException();
    }

    public Task SaveTransaction()
    {
        throw new System.NotImplementedException();
    }

    public Task UpdateAll()
    {
        throw new System.NotImplementedException();
    }
}
