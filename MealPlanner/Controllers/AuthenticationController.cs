using MealPlannerAPI.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    [Route("api")]
    //[Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> logger;
        private readonly IAuthService authService;
        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthService authService)
        {
            this.logger = logger;
            this.authService = authService;
        }

        [HttpPost("/create-token")]
        //[AllowAnonymous]
        public async Task<IActionResult> CreateJwtToken([FromBody] string userName)
        {
            var token = authService.GenerateJwtToken(userName);

            return Ok(new { Token = token });
        }


        //var json = JsonSerializer.Deserialize<TestJson>(jsonBodyContent);

        //public record TestJson(string name, string type, int quantity, bool flag);
    }
}
