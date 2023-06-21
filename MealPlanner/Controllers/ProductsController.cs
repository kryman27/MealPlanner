using MealPlannerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    public class MealPlannerController : ControllerBase
    {
        [Route("GetProducts")]
        [HttpGet]
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

        [HttpPost("AddNewProduct/{name}/{fat}/{carb}/{prot}/{enrg}")]
        public void AddNewProduct(string name, double fat, double carb, double prot, double enrg)
        {
            Product insertProd = new Product();
            insertProd.ProductName = name;
            insertProd.Fat = fat;
            insertProd.Carbohydrates = carb;
            insertProd.Protein = prot;
            insertProd.Energy = enrg;


            using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
            {
                try
                {
                    dbCtx.Products.Add(insertProd);
                    dbCtx.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
