namespace ModelsLib.Model;

public partial class Meal
{
    public Meal()
    {

    }
    public Meal(int mealId, DateTime? mealDate, string mealName, ICollection<MealDetail> mealDetails)
    {
        MealId = mealId;
        MealDate = mealDate;
        MealName = mealName;
        MealDetails = mealDetails;
    }


    public int MealId { get; set; }

    public DateTime? MealDate { get; set; }

    public string MealName { get; set; }

    public virtual ICollection<MealDetail> MealDetails { get; set; } = new List<MealDetail>();
}
