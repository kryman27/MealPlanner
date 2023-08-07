namespace MealPlannerUI.Data
{
    public class CustomMealCalculator : ProductInfo
    {
        public double Amount { get; set; }
        public static ProductInfo CalculateCustomMeal(List<CustomMealCalculator> givenList)
        {
            return new ProductInfo();
        }
    }
}
