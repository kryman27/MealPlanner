using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Models;

public partial class Product
{
    public int Id { get; set; }

    public string ProductName { get; set; } = null!;

    public int? Category { get; set; }

    public int? Brand { get; set; }

    public double? Fat { get; set; }

    public double? Carbohydrates { get; set; }

    public double? Protein { get; set; }

    public double? Energy { get; set; }

    public virtual Brand? BrandNavigation { get; set; }

    public virtual Category? CategoryNavigation { get; set; }
}
