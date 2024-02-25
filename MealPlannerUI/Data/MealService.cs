using ModelsLib.Model;
using MealPlannerUI.ConfigManager;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Http.Headers;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using System.Text;
using HttpMethod = System.Net.Http.HttpMethod;

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

        public async void AddMealToDb(Meal newMeal)
        {
            try
            {
                using (HttpClient client = new())
                {
                    var requestUrl = $"{apiUrl}/meal";
                    //var json = JsonSerializer.Serialize(newMeal);
                    //var jsonRequestContent = new StringContent(json, Encoding.UTF8, "application/json");

                    //HttpResponseMessage response = await client.PostAsync(requestUrl, jsonRequestContent);

                    //return Results.Ok(response.StatusCode);


                    var jsonMeal = JsonSerializer.Serialize(newMeal);

                    
                    var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
                    var requestContent = JsonContent.Create(jsonMeal);
                    request.Content = requestContent;

                    //client.Send(request);
                    HttpResponseMessage response = await client.SendAsync(request);
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
