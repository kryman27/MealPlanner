using MealPlannerAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

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

        [HttpGet("GetSingleProduct/{searchCriteria}")]
        public List<Product> GetProduct(string searchCriteria)
        {
            //try
            //{
            using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
            {
                var product = dbCtx.Products.Where(p => p.ProductName.Contains(searchCriteria)).ToList<Product>();
                return product;
            }
            //}
            //catch (Exception ex)
            //{
            //    Product e = new Product();
            //    e.ProductName = ex.Message;
            //    return e;
            //}
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

        [HttpPost("DeleteSelected")]
        public void DeleteSelected(string ids)
        {
            using(MealPlannerDbContext dbCtx = new MealPlannerDbContext())
            {
                try
                {
                    var deserializeJson = JsonConvert.DeserializeObject(ids);
                    foreach (var i in ids)
                    {
                        var recordToDelete = dbCtx.Products.FirstOrDefault(x => x.IdProduct == i);

                        dbCtx.Products.Remove(recordToDelete);
                        dbCtx.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
