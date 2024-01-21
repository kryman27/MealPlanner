namespace MealPlannerAPI.Model
{
    public class MealDetail
    {
        public MealDetail()
        {

        }
        public MealDetail(int mealId, int productId, decimal amount)
        {
            MealId = mealId;
            ProductId = productId;
            Amount = amount;
        }

        public int MealDetailId { get; set; }

        public int MealId { get; set; }

        public int ProductId { get; set; }
        public decimal Amount { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
