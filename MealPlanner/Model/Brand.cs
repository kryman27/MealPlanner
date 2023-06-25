using System;
using System.Collections.Generic;

namespace MealPlannerAPI.Model;

public partial class Brand
{
    public int IdBrand { get; set; }

    public string? BrandName { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
