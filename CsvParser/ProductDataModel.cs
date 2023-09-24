namespace FileParser
{
    public class ProductDataModel
    {
        public string? ProductName { get; set; }
        public double Fat { get; set; }
        public double Carbohydrates { get; set; }
        public double Proteins { get; set; }
        public double Energy { get; set; }

        public ProductDataModel(string productName, double fat, double carbs, double proteins, double energy)
        {
            ProductName = productName;
            Fat = fat;
            Carbohydrates = carbs;
            Proteins = proteins;
            Energy = energy;
        }

        public ProductDataModel() { }
    }
}
