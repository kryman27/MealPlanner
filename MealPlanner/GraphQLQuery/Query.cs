﻿using MealPlannerAPI.Database;
using Microsoft.EntityFrameworkCore;
using ModelsLib.Model;

namespace MealPlannerAPI.GraphQLQuery
{
    public class Query
    {
        //[UseFiltering(typeof(ProductFilter))]
        public List<Product> GetProdutcs()
        {
            using (MealPlannerDbContext ctx = new MealPlannerDbContext())
            {
                var products = ctx.Products.ToList();

                return products;
            }
        }

        public List<Meal> GetMeals()
        {
            using (var ctx = new MealPlannerDbContext())
            {
                var meals = ctx.Meals.Include(md => md.MealDetails).ThenInclude(p => p.Product).ToList();

                return meals;
            }
        }
    }
}
