using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using ConsumeThirdPartyApisDemo.Models;

namespace ConsumeThirdPartyApisDemo.Services
{
    public class DataService : IDataService
    {

        public async Task<List<DataModel>> GetData()
        {
            HttpClient httpClient = new HttpClient();
            List<DataModel> dataModels = new List<DataModel>();
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, "https://api.github.com/users/hadley/orgs");
            requestMessage.Headers.Add("User-Agent", "User-Agent-Here");
            HttpResponseMessage response = await httpClient.SendAsync(requestMessage);

            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                var data = JsonSerializer.Deserialize<List<DataModel>>(stringResponse,
                    new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                //filter the data on the basis of condition
                var maxObject = data.OrderByDescending(item => item.id).First();
                var minObject = data.OrderByDescending(item => item.id).Last();
                dataModels.Add(maxObject);
                dataModels.Add(minObject);
            }
            else
            {
                throw new HttpRequestException(response.ReasonPhrase);
            }

            return dataModels;
        }
    }
}
