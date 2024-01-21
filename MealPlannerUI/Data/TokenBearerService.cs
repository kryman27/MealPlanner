using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text;
using static System.Net.WebRequestMethods;
using Newtonsoft.Json;
using System.Text.Json;

namespace MealPlannerUI.Data
{
    public class TokenBearerService
    {
        public string Token { get; set; }
        public string Url { get; set; } = "http://localhost:5068/create-token";

        public string RetreiveToken(string userName)
        {
            using(HttpClient client = new HttpClient())
            {
                var request = new HttpRequestMessage(HttpMethod.Post, Url);

                request.Content = new StringContent(JsonConvert.SerializeObject(userName), Encoding.UTF8, "application/json");
                

                var response = client.Send(request);
                var token = response.Content.ReadAsStringAsync().Result;
                var deserializedToken = System.Text.Json.JsonSerializer.Deserialize<Token>(token);

                Token = deserializedToken.token;

                return deserializedToken.token;
            }
        }
    }

    public record Token (string token);
}
