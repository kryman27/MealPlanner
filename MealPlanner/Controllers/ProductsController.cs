using EnumStringValues;
using MealPlannerAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModelsLib.Model;
using System.Text.Json;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    //[Authorize]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        public ProductController(ILogger<ProductController> logger)
        {
            this.logger = logger;
        }

        [Route("products")]
        [HttpGet]
        public IResult GetProducts()
        {
            try
            {
                using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
                {
                    var products = dbCtx.Products.ToList<Product>();
                    //var result = JsonSerializer.Serialize(products);
                    //Response.Headers.Add("X-test-header", "666");
                    logger.LogInformation(LoggerInfo.ProductFound.GetStringValue());
                    return Results.Ok(products);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(LoggerInfo.Error.GetStringValue() + "\n" + ex.Message);
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet("product/{searchName}")]
        public IResult GetProduct(string searchName)
        {
            try
            {
                using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
                {
                    var product = dbCtx.Products.Where(p => p.ProductName.Contains(searchName)).ToList<Product>();

                    logger.LogInformation(LoggerInfo.ProductFound.GetStringValue() + $" by name: {searchName}");
                    return Results.Ok(product);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(LoggerInfo.Error.GetStringValue() + "\n" + ex.Message);
                return Results.Problem(ex.Message);
            }
        }

        [HttpPost("product")]
        public IResult AddNewProduct([FromBody] string newProduct)
        {
            Product insertProd = JsonSerializer.Deserialize<Product>(newProduct);


            using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
            {
                try
                {
                    dbCtx.Products.Add(insertProd);
                    dbCtx.SaveChanges();

                    int id = insertProd.ProductId;

                    logger.LogInformation(LoggerInfo.ProductAdded.GetStringValue() + $" with ID: {id}");
                    return Results.Ok(id);
                }
                catch (DbUpdateException ex)
                {
                    logger.LogError(LoggerInfo.Error.GetStringValue() + $" {ex.Message}");
                    return Results.Problem(ex.Message);
                }
            }
        }

        [HttpDelete("product/{id}")]
        public IResult DeleteSelected(int id)
        {
            using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
            {
                try
                {
                    var recordToDelete = dbCtx.Products.FirstOrDefault(x => x.ProductId == id);

                    dbCtx.Products.Remove(recordToDelete);
                    dbCtx.SaveChanges();

                    logger.LogInformation(LoggerInfo.Deleted.GetStringValue());
                    return Results.Ok($"Deleted record's id: {recordToDelete.ProductId}");

                }
                catch (Exception ex)
                {
                    logger.LogError(LoggerInfo.Error.GetStringValue() + $" {ex.Message}");
                    return Results.Problem(ex.Message);
                }
            }
        }

        [HttpPut("product/{name}/{fat}/{carb}/{prot}/{enrg}")]
        public IResult UpdateSelected(string name, decimal fat, decimal carb, decimal prot, decimal enrg)
        {
            try
            {
                using (MealPlannerDbContext dbCtx = new())
                {
                    var recordToUpdate = dbCtx.Products.FirstOrDefault(p => p.ProductName == name);
                    recordToUpdate.ProductName = name;
                    recordToUpdate.Fat = fat;
                    recordToUpdate.Carbohydrates = carb;
                    recordToUpdate.Protein = prot;
                    recordToUpdate.Energy = enrg;

                    dbCtx.Products.Update(recordToUpdate);
                    dbCtx.SaveChanges();
                    int updatedProductID = recordToUpdate.ProductId;

                    logger.LogInformation($"Product with ID: {updatedProductID} " + LoggerInfo.Updated.GetStringValue());
                    return Results.Ok(updatedProductID);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(LoggerInfo.Error.GetStringValue() + $" {ex.Message}");
                return Results.Problem(ex.Message);
            }
        }

        [HttpPatch("patch-product/{name}")]
        public IResult PatchProduct(string name, decimal? fat, decimal? carb, decimal? prot, decimal? enrg)
        {
            try
            {
                using (MealPlannerDbContext dbCtx = new())
                {
                    var recordToUpdate = dbCtx.Products.FirstOrDefault(p => p.ProductName == name);

                    recordToUpdate.ProductName = name;

                    recordToUpdate.Fat = (fat != null) ? fat : recordToUpdate.Fat;
                    recordToUpdate.Carbohydrates = (carb != null) ? carb : recordToUpdate.Carbohydrates;
                    recordToUpdate.Protein = (prot != null) ? prot : recordToUpdate.Protein;
                    recordToUpdate.Energy = (enrg != null) ? enrg : recordToUpdate.Energy;

                    dbCtx.Products.Update(recordToUpdate);
                    dbCtx.SaveChanges();
                    int updatedProductID = recordToUpdate.ProductId;

                    logger.LogInformation($"Product with ID: {updatedProductID} " + LoggerInfo.Updated.GetStringValue());
                    return Results.Ok(updatedProductID);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(LoggerInfo.Error.GetStringValue() + $" {ex.Message}");
                return Results.Problem(ex.Message);
            }
        }

        [Route("paginated-products/{productsPerPage}/{pageNumber}")]
        [HttpGet]
        public IResult GetPaginatedProducts(int productsPerPage, int pageNumber)
        {
            int initialIndex = productsPerPage * pageNumber;
            double totalNumberOfPages;
            try
            {
                using (MealPlannerDbContext dbCtx = new MealPlannerDbContext())
                {
                    totalNumberOfPages = (double)dbCtx.Products.Count() / (double)productsPerPage;

                    var products = dbCtx.Products.Skip(initialIndex - productsPerPage).Take(productsPerPage).ToList();
                    Response.Headers.Add("X-number-of-pages", $"{Math.Round(totalNumberOfPages, MidpointRounding.ToPositiveInfinity)}");
                    logger.LogInformation(LoggerInfo.ProductFound.GetStringValue());
                    return Results.Ok(products);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(LoggerInfo.Error.GetStringValue() + "\n" + ex.Message);
                return Results.Problem(ex.Message);
            }
        }
    }
}
