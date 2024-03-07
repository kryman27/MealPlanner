using MealPlannerAPI.Authentication;
using MealPlannerAPI.Database;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsLib.DTOs;
using ModelsLib.Model;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MealPlannerAPI.Controllers
{
    [ApiController]
    [Route("api/")]
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

        [HttpPost("login")]
        //[AllowAnonymous]
        public IResult CreateJwtToken([FromBody] UserData givenUserData)
        {
            UserDataDTO result = null;

            //TODO - dodanie sprawdzenia hasła i loginu w tabeli UserData
            
            using(MealPlannerDbContext dbCtx = new())
            {
                var userData = dbCtx.UserData.Where(x => x.UserName == givenUserData.UserName).FirstOrDefault();
                if (userData == null)
                {
                    return Results.Ok("user not found");
                }
                if(userData != null)
                {
                    if(userData.UserName == givenUserData.UserName && userData.UserPassword == givenUserData.UserPassword)
                    {
                        var token = authService.GenerateJwtToken(givenUserData.UserName);

                        result = new UserDataDTO(userData.UserId, userData.UserName, token);
                    }
                }
            }
            
            return Results.Ok(result);
        }


        //var json = JsonSerializer.Deserialize<TestJson>(jsonBodyContent);

        //public record TestJson(string name, string type, int quantity, bool flag);
    }
}
