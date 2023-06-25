using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class Product
{
    public int IdProduct { get; set; }

    public string ProductName { get; set; } = null!;

    public int? IdCategory { get; set; }

    public int? IdBrand { get; set; }

    public double? Fat { get; set; }

    public double? Carbohydrates { get; set; }

    public double? Protein { get; set; }

    public double? Energy { get; set; }

    public virtual ICollection<DailyMeal> DailyMeals { get; set; } = new List<DailyMeal>();

    public virtual Brand? IdBrandNavigation { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }
}
