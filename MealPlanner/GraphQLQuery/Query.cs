using MealPlannerAPI.Database;
using MealPlannerAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MealPlannerAPI.GraphQLQuery
{
    public class Query
    {
        //[UseFiltering(typeof(ProductFilter))]
        public DbSet<Product> GetProdutcs()
        {
            using var ctx = new MealPlannerDbContext();

            var products = ctx.Products;

            return products;

        }

        public List<Meal> GetMeals()
        {
            var ctx = new MealPlannerDbContext();

            var meals = ctx.Meals.Include(md => md.MealDetails).ThenInclude(p => p.Product).ToList();

            return meals;
        }
    }
}
