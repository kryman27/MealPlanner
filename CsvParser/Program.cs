using System.Globalization;

namespace CsvParser
{
    public class CsvParser
    {
        public static void Main()
        {
            List<SingleEntry> entries = new List<SingleEntry>();

            string filePath = @"C:\Users\user\source\repos\MealPlanner\DbContent.csv";
            try
            {
                string[] fileContent = File.ReadAllLines(filePath);
                foreach (string line in fileContent)
                {
                    string[] values = line.Split(',');

                    try
                    {
                        entries.Add(new SingleEntry(values[0],
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

            string dbQueryPath = @"C:\Users\user\source\repos\MealPlanner\dbQuery.sql";
            foreach (var entry in entries)
            {
                string query = $"INSERT INTO Products (product_name, fat, protein, carbohydrates, energy) VALUES('{entry.Product.ToString(CultureInfo.InvariantCulture)}', {entry.Fat.ToString(CultureInfo.InvariantCulture)}, {entry.Carbohydrates.ToString(CultureInfo.InvariantCulture)}, {entry.Proteins.ToString(CultureInfo.InvariantCulture)}, {entry.Energy.ToString(CultureInfo.InvariantCulture)})";
                Console.WriteLine(query);
                try
                {
                    using (StreamWriter sw = File.AppendText(dbQueryPath))
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
