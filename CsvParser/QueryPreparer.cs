using System.Globalization;

namespace FileParser
{
    public class QueryPreparer
    {
        public void PrepareQuery(List<ProductDataModel> data, string outputPath)
        {
            foreach (var entry in data)
            {
                string query = $"INSERT INTO Products (ProductName, Fat, Carbohydrates, Protein, Energy)" +
                    $" VALUES('{entry.ProductName.ToString(CultureInfo.InvariantCulture)}'," +
                    $" {entry.Fat.ToString(CultureInfo.InvariantCulture)}," +
                    $" {entry.Carbohydrates.ToString(CultureInfo.InvariantCulture)}," +
                    $" {entry.Proteins.ToString(CultureInfo.InvariantCulture)}," +
                    $" {entry.Energy.ToString(CultureInfo.InvariantCulture)})";
                Console.WriteLine(query);
                try
                {
                    using (StreamWriter sw = File.AppendText(outputPath))
                    {
                        sw.WriteLine(query);
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Exit code: 1");
                    System.Environment.Exit(1);
                }
            }
        }
    }
}
