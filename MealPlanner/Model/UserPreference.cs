using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class UserPreference
{
    public UserPreference(int userId, string userName, int? dailyEnrgGoalLow, int? dailyEnrgGoalHigh, int? dailyFatGoal, int? dailyCarbsGoal, int? dailyProteinsGoal)
    {
        UserId = userId;
        UserName = userName;
        DailyEnrgGoalLow = dailyEnrgGoalLow;
        DailyEnrgGoalHigh = dailyEnrgGoalHigh;
        DailyFatGoal = dailyFatGoal;
        DailyCarbsGoal = dailyCarbsGoal;
        DailyProteinsGoal = dailyProteinsGoal;
    }

    public int UserPreferenceId { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; }

    public int? DailyEnrgGoalLow { get; set; }

    public int? DailyEnrgGoalHigh { get; set; }

    public int? DailyFatGoal { get; set; }

    public int? DailyCarbsGoal { get; set; }

    public int? DailyProteinsGoal { get; set; }
}
