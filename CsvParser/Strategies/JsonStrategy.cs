using System.Text.Json;

namespace FileParser.Strategies
{
    public class JsonStrategy : IParseStrategies
    {
        public string filePath { get; set; }
        public List<ProductDataModel> Execute(string filePath)
        {
            List<ProductDataModel> ProductData = new List<ProductDataModel>();
            try
            {
                var json = File.ReadAllText(filePath);

                ProductData.AddRange(JsonSerializer.Deserialize<List<ProductDataModel>>(json));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ProductData;
        }
    }
}
