using ModelsLib.Model;

using System.Text;
using System.Text.Json;

namespace MealPlannerUI.Data;
public class UserPreferencesService
{

    private readonly string apiUrl;

    public UserPreferencesService()
    {
        apiUrl = ConfigManager.ConfigManager.GetInstance().apiUrl;
    }

    public UserPreference RetriveUserPreferences(int userId)
    {
        using (HttpClient client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{apiUrl}/preferences/{userId}");

            //request.Content = new StringContent(userId.ToString(), Encoding.UTF8, "application/json");


            var response = client.Send(request);
            var userPreferences = response.Content.ReadFromJsonAsync<UserPreference>().Result;
            //var userPreferencesRaw = response.Content.ReadAsStringAsync().Result;
            //var userPreferences = JsonSerializer.Deserialize<UserPreference>(userPreferencesRaw);

            return userPreferences;
        }
    }

    public UserPreference ModifyPreferences(UserPreference pref)
    {
        using (HttpClient client = new HttpClient())
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{apiUrl}/modify-preferences");

            request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(pref), Encoding.UTF8, "application/json");


            var response = client.Send(request);
            
            var userPreferences = response.Content.ReadFromJsonAsync<UserPreference>().Result;
            //var userPreferencesRaw = response.Content.ReadAsStringAsync().Result;
            //var userPreferences = JsonSerializer.Deserialize<UserPreference>(userPreferencesRaw);

            return userPreferences;
        }
    }
}
