using ModelsLib.Model;
using MealPlannerUI.ConfigManager;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Headers;

namespace MealPlannerUI.Data
{
    public class MealService
    {
        public readonly string apiUrl;

        public MealService()
        {
            var url = ConfigManager.ConfigManager.GetInstance();
            apiUrl = url.apiUrl;
        }

        public async Task<List<Meal>> GetMeals(DateTime date)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var urlDate = date.ToString();
                    string requestUrl = $"{apiUrl}/meals-by-date/{urlDate}";

                    var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);

                    var response = await client.SendAsync(request);
                    string rawData = response.Content.ReadAsStringAsync().Result;

                    var result = JsonSerializer.Deserialize<List<Meal>>(rawData);

                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}
