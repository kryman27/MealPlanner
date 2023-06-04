﻿using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string? BrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
