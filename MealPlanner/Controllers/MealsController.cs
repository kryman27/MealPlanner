using MealPlannerAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLib.Model;

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

        //[HttpPost]
        //[Route("meal")]
        //public IResult CreateCustomMeal(Meal meal)
        //{

        //}
    }
}
