﻿using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class Category
{
    public int IdCategory { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
