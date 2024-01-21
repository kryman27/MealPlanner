using EnumStringValues;
using MealPlannerAPI.Database;
using MealPlannerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/user-preferences")]
    public class UserPreferencesController : ControllerBase
    {
        private readonly ILogger<UserPreferencesController> logger;
        public UserPreferencesController(ILogger<UserPreferencesController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("preferences/{userId}")]
        public IResult GetUserPreferences(int userId)
        {
            UserPreference? userPreferences;
            using (MealPlannerDbContext dbCtx = new())
            {
                userPreferences = dbCtx.UserPreferences.Where(id => id.UserId == userId).FirstOrDefault();
            }

            return Results.Ok(userPreferences);
        }

        [HttpPost("preferences")]
        public IResult AddUserPreferences(int userId, string userName, int dailyEnergyGoalLow, int dailyEnergyGoalHigh, int dailyFatGoal, int dailyCarbsGoal, int dailyProteinsGoal)
        {
            UserPreference userPreference = new(userId, userName, dailyEnergyGoalLow, dailyEnergyGoalHigh, dailyFatGoal, dailyCarbsGoal, dailyProteinsGoal);

            using(MealPlannerDbContext dbCtx = new())
            {
                dbCtx.UserPreferences.Add(userPreference);
                dbCtx.SaveChanges();

                int id = userPreference.UserPreferenceId;

                logger.LogInformation(LoggerInfo.UserPreferencesAdded.GetStringValue() + $" with ID: {id}");
                return Results.Ok(id);
            }
        }
    }
}
