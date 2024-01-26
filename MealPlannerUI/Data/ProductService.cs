using ModelsLib.Model;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MealPlannerUI.Data
{
    public class ProductService
    {
        //private readonly TokenBearerService TokenBearerSvc;
        public static string dbLoadingExMsg = "unknown error";
        //public readonly string apiUrl = "http://localhost:5068/api";
        public readonly string apiUrl = "http://localhost:5000/api";

        public ProductService()
        {
            //TokenBearerSvc = new();
            //TokenBearerSvc.RetreiveToken("MealPlannerAPI");
        }

        public async Task<Product[]> GetProductsInfo()
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

                    var productInfoToDisplay = JsonConvert.DeserializeObject<Product[]>(rawData);

                    return productInfoToDisplay;
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }

            Product[] error = new Product[1]
            {
                new Product
                {
                    ProductName = dbLoadingExMsg
                }
            };
            return error;
        }

        public async Task<AnswerModel<Product[]>> GetPaginatedProducts(int productsPerPage, int pageNumber)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productsApiUrl = $"{apiUrl}/paginated-products/{productsPerPage}/{pageNumber}";

                    var request = new HttpRequestMessage(HttpMethod.Get, productsApiUrl);
                    //request.Headers.Add("Authorization", $"Bearer {TokenBearerSvc.Token}");

                    var response = await client.SendAsync(request);

                    string rawData = response.Content.ReadAsStringAsync().Result;

                    var productInfoToDisplay = JsonConvert.DeserializeObject<Product[]>(rawData);

                    var currentNumberOfPages = response.Headers.NonValidated.FirstOrDefault(h => h.Key == "X-number-of-pages").Value.ToString();

                    return new AnswerModel<Product[]>(productInfoToDisplay, currentNumberOfPages);
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }

            var productInfoToDisplayError = new Product[1];
            {
                new Product
                {
                    ProductName = dbLoadingExMsg
                };
            };
            return new AnswerModel<Product[]>(productInfoToDisplayError, "error");
        }

        public async Task<List<Product>> GetSingleProductInfo(string searchName)
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

                    var productInfoToDisplay = JsonConvert.DeserializeObject<List<Product>>(rawData);

                    return productInfoToDisplay;
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }
            List<Product> error = new List<Product> { new Product { ProductName = dbLoadingExMsg } };
            {
                new Product
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
