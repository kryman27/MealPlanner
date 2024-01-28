using System.Text.Json.Serialization;

namespace ModelsLib.Model;

public partial class Meal
{
    public Meal()
    {

    }

    [JsonConstructor]
    public Meal(int mealId, DateTime? mealDate, string mealName)
    {
        MealId = mealId;
        MealDate = mealDate;
        MealName = mealName;
    }

    public Meal(int mealId, DateTime? mealDate, string mealName, ICollection<MealDetail> mealDetails)
    {
        MealId = mealId;
        MealDate = mealDate;
        MealName = mealName;
        MealDetails = mealDetails;
    }

    [JsonPropertyName("mealId")]
    public int MealId { get; set; }

    [JsonPropertyName("mealDate")]
    public DateTime? MealDate { get; set; }

    [JsonPropertyName("mealName")]
    public string MealName { get; set; }

    [JsonPropertyName("mealDetails")]
    public virtual ICollection<MealDetail> MealDetails { get; set; } = new List<MealDetail>();
}
