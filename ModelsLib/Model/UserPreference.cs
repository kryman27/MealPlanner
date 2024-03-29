﻿namespace ModelsLib.Model;

public partial class UserPreference
{
    public UserPreference(int userId, string userName, int? dailyEnrgGoal, int? dailyFatGoal, int? dailyCarbsGoal, int? dailyProteinsGoal)
    {
        UserId = userId;
        UserName = userName;
        DailyEnrgGoal = dailyEnrgGoal;
        DailyFatGoal = dailyFatGoal;
        DailyCarbsGoal = dailyCarbsGoal;
        DailyProteinsGoal = dailyProteinsGoal;
    }

    public int UserPreferenceId { get; set; }

    public int UserId { get; set; }

    public string UserName { get; set; }

    public int? DailyEnrgGoal { get; set; }

    public int? DailyFatGoal { get; set; }

    public int? DailyCarbsGoal { get; set; }

    public int? DailyProteinsGoal { get; set; }
}
