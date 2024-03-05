using EnumStringValues;
using MealPlannerAPI.Database;
using Microsoft.AspNetCore.Mvc;
using ModelsLib.Model;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/")]
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
        public IResult AddUserPreferences(int userId, string userName, int dailyEnergyGoalHigh, int dailyFatGoal, int dailyCarbsGoal, int dailyProteinsGoal)
        {
            UserPreference userPreference = new(userId, userName, dailyEnergyGoalHigh, dailyFatGoal, dailyCarbsGoal, dailyProteinsGoal);

            using (MealPlannerDbContext dbCtx = new())
            {
                dbCtx.UserPreferences.Add(userPreference);
                dbCtx.SaveChanges();

                int id = userPreference.UserPreferenceId;

                logger.LogInformation(LoggerInfo.UserPreferencesAdded.GetStringValue() + $" with ID: {id}");
                return Results.Ok(id);
            }
        }

        [HttpPost("modify-preferences")]
        public IResult ModifyUserPreferences([FromBody]UserPreference userPreference)
        {
            using(MealPlannerDbContext dbCtx = new())
            {
                var dbUserPref = dbCtx.UserPreferences.Update(userPreference);
                dbCtx.SaveChanges();

                //logger.LogInformation();

                return Results.Ok(userPreference);
            }
        }
    }
}
