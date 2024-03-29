﻿using MealPlannerUI.Pages;
using ModelsLib.Model;

namespace MealPlannerUI.Data
{
    public class CustomsCalculator
    {
        public static Product CalculateCustomProduct(List<ProductIngredient> givenList)
        {
            if (givenList == null || givenList.Count == 0)
            {
                return null;
            }
            decimal totalMass = Convert.ToDecimal(givenList.Sum(p => p.Amount));
            decimal totalFat = Convert.ToDecimal(givenList.Sum(p => p.Fat));
            decimal totalCarbs = Convert.ToDecimal(givenList.Sum(p => p.Carbohydrates));
            decimal totalProtein = Convert.ToDecimal(givenList.Sum(p => p.Protein));
            decimal totalEnergy = Convert.ToDecimal(givenList.Sum(p => p.Energy));

            //Calculating values per 100g
            var carbs = Math.Round(((totalCarbs * 100.0m) / totalMass), 2);
            var fat = Math.Round(((totalFat * 100.0m) / totalMass), 2);
            var protein = Math.Round(((totalProtein * 100.0m) / totalMass), 2);
            var energy = Math.Round(((totalEnergy * 100.0m) / totalMass), 2);

            var result = new Product(string.Empty, fat, carbs, protein, energy);

            return result;
        }

        public static List<MealDetail> CalculateMealDetails(List<ProductIngredient> input)
        {
            var result = new List<MealDetail>();

            foreach (var product in input)
            {
                result.Add(new MealDetail(product.ProductId, product.Amount));
            }


            return result;
        }
    }
}
