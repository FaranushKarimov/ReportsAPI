using Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Services
{
    public class IncomeService : IIncomeService
    {
        public async Task UpdateAsync()
        {
            var client = new RestClient($"https://localhost:5001/Wildberries/GetIncomes");
            var request = new RestRequest($"https://localhost:5001/Wildberries/GetIncomes", Method.Get);

            RestResponse response = await client.ExecuteAsync(request);

            Console.WriteLine(response.ErrorMessage);
            Console.WriteLine(response.StatusDescription);
        }
    }
}
