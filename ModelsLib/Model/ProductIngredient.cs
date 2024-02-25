namespace ModelsLib.Model
{
    public class ProductIngredient
    {
        public ProductIngredient(decimal amount, int productId, string productName, decimal? fat, decimal? carbohydrates, decimal? protein, decimal? energy)
        {
            Amount = amount;
            ProductId = productId;
            ProductName = productName;
            Fat = fat;
            Carbohydrates = carbohydrates;
            Protein = protein;
            Energy = energy;
        }

        public decimal Amount { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal? Fat { get; set; }
        public decimal? Carbohydrates { get; set; }
        public decimal? Protein { get; set; }
        public decimal? Energy { get; set; }
    }
}
