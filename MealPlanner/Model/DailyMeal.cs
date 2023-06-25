using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class DailyMeal
{
    public int IdDailyMeal { get; set; }

    public int? MealId { get; set; }

    public int? ProductId { get; set; }

    public DateTime? DailyMealDate { get; set; }

    public virtual Meal? Meal { get; set; }

    public virtual Product? Product { get; set; }
}
