namespace MealPlannerUI.Data
{
    public class ProductInfo
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public int? Category { get; set; }

        public int? Brand { get; set; }

        public double? Fat { get; set; }

        public double? Carbohydrates { get; set; }

        public double? Protein { get; set; }

        public double? Energy { get; set; }
    }
}
