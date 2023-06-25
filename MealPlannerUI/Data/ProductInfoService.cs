using Newtonsoft.Json;

namespace MealPlannerUI.Data
{
    public class ProductInfoService
    {
        public static string dbLoadingExMsg = "unknown error";
        public async Task<ProductInfo[]> GetProductsInfo()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productsApiUrl = "http://localhost:5068/GetProducts";

                    HttpResponseMessage response = await client.GetAsync(productsApiUrl);
                    string rawData = await response.Content.ReadAsStringAsync();

                    var productInfoToDisplay = JsonConvert.DeserializeObject<ProductInfo[]>(rawData);

                    return productInfoToDisplay;
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }

            ProductInfo[] error = new ProductInfo[1]
            {
                new ProductInfo
                {
                    ProductName = dbLoadingExMsg
                }
            };
            return error;
        }

        public async Task<ProductInfo[]> GetSingleProductInfo(string searchCriteria)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productApiUrl = $"http://localhost:5068/GetSingleProduct/{searchCriteria}";
                    HttpResponseMessage response = await client.GetAsync(productApiUrl);
                    string rawData = await response.Content.ReadAsStringAsync();

                    var productInfoToDisplay = JsonConvert.DeserializeObject<ProductInfo[]>(rawData);

                    return productInfoToDisplay;
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }
            ProductInfo[] error = new ProductInfo[1];
            {
                new ProductInfo
                {
                    ProductName = dbLoadingExMsg
                };
            }

            return error;
        }
    }
}
