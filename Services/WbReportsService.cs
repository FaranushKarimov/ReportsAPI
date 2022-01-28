using System;
using RestSharp;
using Entities.Models;
using Newtonsoft.Json;
using Entities.DataContexts;
using System.Threading.Tasks;
using System.Collections.Generic;

public class WbReportsService : IWbReportsService
{
    private readonly DataContext _db;

    public WbReportsService(DataContext db)
    {
        _db = db;
    }

    public async Task<List<Income>> GetIncomesAsync()
    {
        var date = Uri.EscapeDataString((DateTime.Today.ToString("yyyy-MM-ddT00:00:00.000Z")));

        string baseUrl = $"https://suppliers-stats.wildberries.ru/api/v1/supplier/incomes?dateFrom={date}&key={Credentials.WB_API_KEY}";
        var client = new RestClient(baseUrl);
        var request = new RestRequest(baseUrl, Method.Get);
        RestResponse response = await client.ExecuteAsync(request);

        var stock = JsonConvert.DeserializeObject<List<Income>>(response.Content);

        return stock;
    }

    public async Task<List<OrderResult>> GetOrdersAsync()
    {
        string date = Uri.EscapeDataString((DateTime.Today.ToString("yyyy-MM-ddT00:00:00.000Z")));

        string baseUrl = $"https://suppliers-stats.wildberries.ru/api/v1/supplier/orders?dateFrom={date}&flag=0&key={Credentials.WB_API_KEY}";
        var client = new RestClient(baseUrl);
        var request = new RestRequest(baseUrl, Method.Get);
        // TODO: REMOVE THIS OR FIND A SOLUTION
        request.Timeout = 1000000;

        RestResponse response = await client.ExecuteAsync(request);

        var report = JsonConvert.DeserializeObject<List<OrderResult>>(response.Content);
        return report;
    }

    public async Task<List<ReportDetailByPeriod>> GetReportsAsync()
    {
        string datefrom = Uri.EscapeDataString((DateTime.Today.AddDays(-15).ToString("yyyy-MM-ddT00:00:00.000Z")));
        string dateto = Uri.EscapeDataString((DateTime.Today.ToString("yyyy-MM-ddT00:00:00.000Z")));

        string baseUrl = $"https://suppliers-stats.wildberries.ru/api/v1/supplier/reportDetailByPeriod?key={Credentials.WB_API_KEY}&datefrom={datefrom}&dateto={dateto}";

        var client = new RestClient(baseUrl);
        var request = new RestRequest(baseUrl, Method.Get);
        RestResponse response = await client.ExecuteAsync(request);

        var report = JsonConvert.DeserializeObject<List<ReportDetailByPeriod>>(response.Content);

        return report;
    }

    public async Task<List<Sale>> GetSalesAsync()
    {
        var datefrom = Uri.EscapeDataString((DateTime.Today.ToString("yyyy-MM-ddTHH:ss:00.000Z")));
        //var datefrom = "2022-01-01T21:00:00.000Zl";

        string baseUrl = $"https://suppliers-stats.wildberries.ru/api/v1/supplier/sales?dateFrom={datefrom}&key={Credentials.WB_API_KEY}";
        var client = new RestClient(baseUrl);
        var request = new RestRequest(baseUrl, Method.Get);
        RestResponse response = await client.ExecuteAsync(request);

        var report = JsonConvert.DeserializeObject<List<Sale>>(response.Content);

        return report;

    }

    public async Task SaveIncomesAsync(List<Income> incomes)
    {
        await _db.Incomes.AddRangeAsync(incomes);

        await _db.SaveChangesAsync();
    }

    public async Task SaveOrdersAsync(List<OrderResult> result)
    {
        await _db.WBOrders.AddRangeAsync(result);
        await _db.SaveChangesAsync();
    }

    public async Task SaveReportsAsync(List<ReportDetailByPeriod> reports)
    {
        await _db.ReportDetailByPeriods.AddRangeAsync(reports);

        await _db.SaveChangesAsync();
    }

    public Task SaveSalesAsync(List<Sale> result)
    {
        throw new NotImplementedException();
    }
}
