using ModelsLib.Model;
using System.Globalization;
using System.Text.Json;

namespace MealPlannerUI.Data
{
    public class AddProductService
    {
        public async void AddProductToDb(string name, double fat, double carbs, double prot, double energy)
        {
            string apiUrl = "http://localhost:5068/api";
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

                    Product newProduct = new(name, Convert.ToDecimal(fat), Convert.ToDecimal(carbs), Convert.ToDecimal(prot), Convert.ToDecimal(energy));

                    var jsonProduct = JsonSerializer.Serialize(newProduct);

                    string addProductApiUrl = $"{apiUrl}/add-product";
                    var request = new HttpRequestMessage(HttpMethod.Post, addProductApiUrl);
                    var requestContent = JsonContent.Create(jsonProduct);
                    request.Content = requestContent;

                    //client.Send(request);
                    HttpResponseMessage response = await client.SendAsync(request);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Rzucono wyjątek: {ex.Message}");
            }
        }
    }
}
