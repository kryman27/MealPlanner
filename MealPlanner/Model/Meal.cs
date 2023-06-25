using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class Meal
{
    public int IdMeal { get; set; }

    public DateTime? MealDate { get; set; }

    public virtual ICollection<DailyMeal> DailyMeals { get; set; } = new List<DailyMeal>();
}
