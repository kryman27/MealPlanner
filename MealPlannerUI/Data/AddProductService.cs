namespace MealPlannerUI.Data
{
    public class AddProductService
    {
        public void AddProductToDb(string name, double fat, double carbs, double prot, double energy)
        {
            using (HttpClient client = new HttpClient())
            {

                string addProductApiUrl = $"http://localhost:5068/AddNewProduct/{name}/{fat}/{carbs}/{prot}/{energy}";
                var request = new HttpRequestMessage(HttpMethod.Post, addProductApiUrl);

                client.Send(request);

            }            
        }
    }
}
