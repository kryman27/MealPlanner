using System.Text.Json.Serialization;

namespace ModelsLib.Model;

public class Product
{
    public Product()
    {

    }
    [JsonConstructor]
    public Product(/*int productId,*/ string productName, decimal? fat, decimal? carbohydrates, decimal? protein, decimal? energy)
    {
        //ProductId = productId;
        ProductName = productName;
        Fat = fat;
        Carbohydrates = carbohydrates;
        Protein = protein;
        Energy = energy;
    }

    [JsonPropertyName("productId")]
    public int ProductId { get; set; }
    
    [JsonPropertyName("productName")]
    public string ProductName { get; set; } = null!;
    
    [JsonPropertyName("fat")]
    public decimal? Fat { get; set; }
    
    [JsonPropertyName("carbohydrates")]
    public decimal? Carbohydrates { get; set; }
    
    [JsonPropertyName("protein")]
    public decimal? Protein { get; set; }
    
    [JsonPropertyName("energy")]
    public decimal? Energy { get; set; }

    //public virtual ICollection<MealDetail> MealDetails { get; set; } = new List<MealDetail>();
}
