using MealPlannerUI.Pages;
using ModelsLib.Model;

namespace MealPlannerUI.Data
{
    public class CustomMealCalculator : Product
    {
        public decimal Amount { get; set; }
        public static void CalculateCustomMeal(List<CustomMealCalculator> givenList)
        {
            if (givenList == null || givenList.Count == 0)
            {
                return;
            }
            decimal totalMass = Convert.ToDecimal(givenList.Sum(p => p.Amount));
            decimal totalFat = Convert.ToDecimal(givenList.Sum(p => p.Fat));
            decimal totalCarbs = Convert.ToDecimal(givenList.Sum(p => p.Carbohydrates));
            decimal totalProtein = Convert.ToDecimal(givenList.Sum(p => p.Protein));
            decimal totalEnergy = Convert.ToDecimal(givenList.Sum(p => p.Energy));
            
            CreateCustomMeal.customProduct.Carbohydrates = Math.Round(((totalCarbs * 100.0m)/totalMass), 2);
            CreateCustomMeal.customProduct.Fat = Math.Round(((totalFat * 100.0m) / totalMass), 2);
            CreateCustomMeal.customProduct.Protein = Math.Round(((totalProtein * 100.0m) / totalMass), 2);
            CreateCustomMeal.customProduct.Energy = Math.Round(((totalEnergy * 100.0m) / totalMass), 2);
        }
    }
}
