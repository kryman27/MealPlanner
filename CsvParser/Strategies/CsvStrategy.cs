using FileParser;
using FileParser.Strategies;
using System.Globalization;

namespace CsvParser.Strategies
{
    public class CsvStrategy : IParseStrategies
    {
        public string filePath { get; set; }
        public List<ProductDataModel> Execute(string filePath)
        {
            List<ProductDataModel> ProductData = new List<ProductDataModel>();
            try
            {
                string[] fileContent = File.ReadAllLines(filePath);
                foreach (string line in fileContent)
                {
                    string[] values = line.Split(',');

                    try
                    {
                        ProductData.Add(new ProductDataModel(values[0],
                                                    double.Parse(values[1], CultureInfo.InvariantCulture),
                                                    double.Parse(values[2], CultureInfo.InvariantCulture),
                                                    double.Parse(values[3], CultureInfo.InvariantCulture),
                                                    double.Parse(values[4], CultureInfo.InvariantCulture)));
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ProductData;
        }
    }
}
