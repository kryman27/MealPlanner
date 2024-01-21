using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MealPlannerUI.Data
{
    public class ProductInfoService
    {
        //private readonly TokenBearerService TokenBearerSvc;
        public static string dbLoadingExMsg = "unknown error";
        public readonly string apiUrl = "http://localhost:5068/api";
        //public readonly string apiUrl = "http://localhost:5000";

        public ProductInfoService()
        {
            //TokenBearerSvc = new();
            //TokenBearerSvc.RetreiveToken("MealPlannerAPI");
        }

        public async Task<ProductInfo[]> GetProductsInfo()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productsApiUrl = $"{apiUrl}/products";
                    
                    var request = new HttpRequestMessage(HttpMethod.Get, productsApiUrl);
                    //request.Headers.Add("Authorization", $"Bearer {TokenBearerSvc.Token}");
                    
                    var response = await client.SendAsync(request);

                    string rawData = response.Content.ReadAsStringAsync().Result;

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

        public async Task<List<ProductInfo>> GetSingleProductInfo(string searchName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productApiUrl = $"{apiUrl}/product/{searchName}";
                    var request = new HttpRequestMessage(HttpMethod.Get, productApiUrl);
                    //request.Headers.Add("Authorization", $"Bearer {TokenBearerSvc.Token}");

                    HttpResponseMessage response = await client.SendAsync(request);
                    string rawData = response.Content.ReadAsStringAsync().Result;

                    var productInfoToDisplay = JsonConvert.DeserializeObject<List<ProductInfo>>(rawData);

                    return productInfoToDisplay;
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }
            List<ProductInfo> error = new List<ProductInfo> { new ProductInfo { ProductName = dbLoadingExMsg } };
            {
                new ProductInfo
                {
                    ProductName = dbLoadingExMsg
                };
            }

            return error;
        }

        public async Task<HttpResponseMessage> DeleteSelectedProduct(int toDelete)
        {
            using(HttpClient client = new HttpClient())
            {
                string deleteApiUrl = $"{apiUrl}/product/{toDelete}";
                
                var response = await client.DeleteAsync(deleteApiUrl);

                return response;
                //if (response.IsSuccessStatusCode)
                //{
                //    var er = response.RequestMessage.Content.ToString();
                //}
                //else
                //{
                //    var er = response.RequestMessage.Content.ToString();
                //}
            }
        }
    }
}
