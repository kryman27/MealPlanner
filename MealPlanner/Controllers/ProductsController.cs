using MealPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    public class MealPlannerController : ControllerBase
    {
        [HttpGet("GetProducts")]
        public List<Product> GetProducts()
        {
            using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
            {
                var products = dbCtx.Products.ToList<Product>();
                return products;
            }
        }

        [HttpGet("GetSingleProduct")]
        public Product GetProduct(string partOfName)
        {
            try
            {
                using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
                {
                    var product = dbCtx.Products.Where(p => p.ProductName.Contains(partOfName)).FirstOrDefault();
                    return product as Product;
                }
            }
            catch (Exception ex)
            {
                Product e = new Product();
                e.ProductName = ex.Message;
                return e;
            }
        }
    }
}
