namespace MealPlannerAPI.Model;

public class Product
{
    public Product()
    {

    }
    public Product(int productId, string productName, decimal? fat, decimal? carbohydrates, decimal? protein, decimal? energy)
    {
        ProductId = productId;
        ProductName = productName;
        Fat = fat;
        Carbohydrates = carbohydrates;
        Protein = protein;
        Energy = energy;
    }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal? Fat { get; set; }

    public decimal? Carbohydrates { get; set; }

    public decimal? Protein { get; set; }

    public decimal? Energy { get; set; }

    public virtual ICollection<MealDetail> MealDetails { get; set; } = new List<MealDetail>();
}
