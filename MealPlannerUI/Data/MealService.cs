using ModelsLib.Model;
using MealPlannerUI.ConfigManager;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

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
                    var urlDate = date.ToString("dd.MM.yyyy");
                    string requestUrl = $"{apiUrl}/meals-by-date/{urlDate}";

                    var response = client.GetFromJsonAsync<List<Meal>>(requestUrl);
                    var result = response.Result;

                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task<IResult> AddMealToDb(Meal newMeal)
        {
            try
            {
                using (HttpClient client = new())
                {
                    var requestUrl = $"{apiUrl}/meal";

                    var request = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, requestUrl);
                    
                    var jsonRequestContent = JsonContent.Create(newMeal);
                    request.Content = jsonRequestContent;

                    var response = await client.SendAsync(request);

                    return Results.Ok(response.StatusCode);
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
