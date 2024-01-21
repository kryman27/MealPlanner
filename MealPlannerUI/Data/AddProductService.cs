using System.Globalization;

namespace MealPlannerUI.Data
{
    public class AddProductService
    {
        public void AddProductToDb(string name, double fat, double carbs, double prot, double energy)
        {
            string apiUrl = "http://localhost:5068/api";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
                    
                    string addProductApiUrl = $"{apiUrl}/product/{name}/{fat}/{carbs}/{prot}/{energy}";
                    var request = new HttpRequestMessage(HttpMethod.Post, addProductApiUrl);

                    client.Send(request);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rzucono wyjątek: {ex.Message}");
            }
        }
    }
}
