using Newtonsoft.Json;

namespace MealPlannerUI.Data
{
    public class ProductInfoService
    {
        public async Task<ProductInfo[]> GetProductsInfo()
        {
            //List<ProductInfo> products = new List<ProductInfo>();
            HttpClient client = new HttpClient();

            string productsApiUrl = "http://localhost:5068/GetProducts";
            //var response = client.GetAsync(connectionPath).Result.ToString();
            //var result = JsonConvert.DeserializeObject<ProductInfo>(response);

            //return result.ToString();

            HttpResponseMessage response = await client.GetAsync(productsApiUrl);
            string rawData = await response.Content.ReadAsStringAsync();

            var productInfoToDisplay = JsonConvert.DeserializeObject<ProductInfo[]>(rawData);

            client.CancelPendingRequests();
            client.Dispose();

            return productInfoToDisplay;
        }
    }
}
