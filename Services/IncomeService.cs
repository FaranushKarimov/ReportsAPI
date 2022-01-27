using RestSharp;
using Contracts.Services;
using System.Threading.Tasks;

namespace Services
{
    public class IncomeService : IIncomeService
    {
        public async Task FetchOzon() {
            var client = new RestClient("https://localhost:5001/");
            var request = new RestRequest("https://localhost:5001/ozon/GetTransaction", Method.Get);
            RestResponse response = await client.ExecuteAsync(request);

            System.Console.WriteLine(response.ErrorException);
            System.Console.WriteLine(response.StatusDescription);
        }

        public async Task UpdateAsync()
        {
            // await FetchOzon();
        }
    }
}
