using MealPlannerAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLib.Model;
using System.Text.Json;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class MealsController : ControllerBase
    {
        private readonly ILogger<MealsController> logger;

        public MealsController(ILogger<MealsController> logger)
        {
            this.logger = logger;
        }

        [HttpGet]
        [Route("meals")]
        public IResult GetMeals()
        {
            using (MealPlannerDbContext dbCtx = new())
            {
                List<Meal> result = dbCtx.Meals.Include(md => md.MealDetails).ThenInclude(p => p.Product).ToList();

                return Results.Ok(result);
            }
        }

        [HttpGet]
        [Route("meals-by-date/{mealDate}")]
        public IResult GetMeals(string mealDate)
        {
            try
            {
                using (MealPlannerDbContext dbCtx = new())
                {
                    var dtDate = DateTime.Parse(mealDate);
                    List<Meal> result = dbCtx.Meals.Where(m => m.MealDate == dtDate).Include(md => md.MealDetails).ThenInclude(p => p.Product).ToList();

                    return Results.Ok(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("meal")]
        public IResult CreateMeal([FromBody] string mealData)
        {
            try
            {
                var newMeal = JsonSerializer.Deserialize<Meal>(mealData);

                using (MealPlannerDbContext dbCtx = new())
                {
                    dbCtx.Meals.Add(newMeal);
                    dbCtx.SaveChanges();
                    return Results.Ok(newMeal.MealId);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        [Route("meal/{mealId}")]
        public IResult DeleteMeal(int mealId)
        {
            using(MealPlannerDbContext dbCtx = new())
            {
                var mealToDelete = dbCtx.Meals.FirstOrDefault(m => m.MealId == mealId);
                dbCtx.Meals.Remove(mealToDelete);
                dbCtx.SaveChanges();

                return Results.Ok(mealToDelete.MealId);
            }
        }
    }
}
