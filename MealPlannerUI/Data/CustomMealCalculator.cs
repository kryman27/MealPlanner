using MealPlannerUI.Pages;

namespace MealPlannerUI.Data
{
    public class CustomMealCalculator : ProductInfo
    {
        public double Amount { get; set; }
        public static void CalculateCustomMeal(List<CustomMealCalculator> givenList)
        {
            double totalMass = givenList.Sum(p => p.Amount);
            double? totalFat = givenList.Sum(p => p.Fat);
            double? totalCarbs = givenList.Sum(p => p.Carbohydrates);
            double? totalProtein = givenList.Sum(p => p.Protein);
            double? totalEnergy = givenList.Sum(p => p.Energy);
            
            CreateCustomMeal.customProduct.Carbohydrates = Math.Round((double)((totalCarbs * 100.0)/totalMass), 2);
            CreateCustomMeal.customProduct.Fat = Math.Round((double)((totalFat * 100.0) / totalMass), 2);
            CreateCustomMeal.customProduct.Protein = Math.Round((double)((totalProtein * 100.0) / totalMass), 2);
            CreateCustomMeal.customProduct.Energy = Math.Round((double)((totalEnergy * 100.0) / totalMass), 2);
        }
    }
}
