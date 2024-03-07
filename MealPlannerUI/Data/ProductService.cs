using ModelsLib.Model;
using System.Globalization;
using System.Text.Json;

namespace MealPlannerUI.Data
{
    public class ProductService
    {
        //private readonly TokenBearerService TokenBearerSvc;
        public static string dbLoadingExMsg = "unknown error";
        public readonly string apiUrl;
       

        public ProductService()
        {
            apiUrl = ConfigManagerNamespace.ConfigManager.GetInstance().apiUrl;

            //TokenBearerSvc = new();
            //TokenBearerSvc.RetreiveToken("MealPlannerAPI");
        }

        public async Task<List<Product>> GetProductsInfo()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productsApiUrl = $"{apiUrl}/products";

                    var productInfoToDisplay = await client.GetFromJsonAsync<List<Product>>(productsApiUrl);

                    return productInfoToDisplay;
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }

            List<Product> error = new()
            {
                new Product
                {
                    ProductName = dbLoadingExMsg
                }
            };
            return error;
        }

        public async Task<AnswerModel<List<Product>>> GetPaginatedProducts(int productsPerPage, int pageNumber)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productsApiUrl = $"{apiUrl}/paginated-products?productsPerPage={productsPerPage}&pageNumber={pageNumber}";

                    var request = new HttpRequestMessage(HttpMethod.Get, productsApiUrl);
                    //request.Headers.Add("Authorization", $"Bearer {TokenBearerSvc.Token}");

                    var response = await client.SendAsync(request);
                    string rawData = response.Content.ReadAsStringAsync().Result;
                    var productInfoToDisplay = JsonSerializer.Deserialize<List<Product>>(rawData);

                    var currentNumberOfPages = response.Headers.NonValidated.FirstOrDefault(h => h.Key == "X-number-of-pages").Value.ToString();

                    return new AnswerModel<List<Product>>(productInfoToDisplay, currentNumberOfPages);
                }
            }
            catch (Exception ex)
            {
                dbLoadingExMsg = ex.Message.ToString();
            }

            List<Product> productInfoToDisplayError = new()
            {
                new Product
                {
                    ProductName = dbLoadingExMsg
                }
            };
            return new AnswerModel<List<Product>>(productInfoToDisplayError, "error");
        }

        public async Task<List<Product>> GetSingleProductInfo(string searchName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string productApiUrl = $"{apiUrl}/product/{searchName}";
                    //var request = new HttpRequestMessage(HttpMethod.Get, productApiUrl);
                    ////request.Headers.Add("Authorization", $"Bearer {TokenBearerSvc.Token}");

                    //HttpResponseMessage response = await client.SendAsync(request);
                    var productInfoToDisplay = await client.GetFromJsonAsync<List<Product>>(productApiUrl);

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
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = null;
                try
                {
                    string deleteApiUrl = $"{apiUrl}/product/{toDelete}";
                    response = await client.DeleteAsync(deleteApiUrl);
                }
                catch (Exception ex)
                {
                    throw;
                }
                return response;
            }
        }

        public async void AddProductToDb(string name, double fat, double carbs, double prot, double energy)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

                    Product newProduct = new(name, Convert.ToDecimal(fat), Convert.ToDecimal(carbs), Convert.ToDecimal(prot), Convert.ToDecimal(energy));

                    var jsonProduct = JsonSerializer.Serialize(newProduct);

                    string addProductApiUrl = $"{apiUrl}/product";
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
