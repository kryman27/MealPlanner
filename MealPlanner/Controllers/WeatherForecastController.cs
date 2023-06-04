using Microsoft.AspNetCore.Mvc;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class DupaCichoController : ControllerBase
    {
        [HttpGet("GetHello")]
        public string GetHello()
        {
            return "Hello fello";
        }

        [HttpGet("GetDupa")]
        public string GetDupa()
        {
            return "Dupa cicho leszczu!";
        }
    }
}