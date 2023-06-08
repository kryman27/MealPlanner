using Microsoft.AspNetCore.Mvc;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet("GetHello")]
        public string GetHello()
        {
            return "Hello fello";
        }

        [HttpGet("GetString")]
        public string GetString()
        {
            return "This is a string for example";
        }

        [HttpPost("PostString/{id}/{input}")]
        public string PostString(int id, string input)
        {
            return $"Posted string: {input} with id: {id}";
        }
    }
}