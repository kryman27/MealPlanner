using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class UserPreference
{
    public int IdUserpreference { get; set; }

    public string UserName { get; set; } = null!;

    public int? DailyEnrgGoalLow { get; set; }

    public int? DailyEnrgGoalHigh { get; set; }

    public int? DailyFatGoal { get; set; }

    public int? DailyCarbsGoal { get; set; }

    public int? DailyProteinsGoal { get; set; }
}
