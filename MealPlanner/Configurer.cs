using MealPlannerAPI.GraphQLQuery;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MealPlannerAPI
{
	public class Configurer
	{
		public static ILogger ConfigureLogger(WebApplicationBuilder builder)
		{
			builder.Logging.AddConsole();
			ILoggerFactory factory = LoggerFactory.Create(log => log.AddConsole());
			ILogger logger = factory.CreateLogger<Program>();

			return logger;
		}

		public static void ConfigureGraphQL(WebApplicationBuilder builder)
		{
			builder.Services.AddGraphQLServer()
			.AddQueryType<Query>()
			.AddFiltering();
		}

		public static void ConfigureAuthenticationAndAuthorization(WebApplicationBuilder builder)
		{
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = false,
					//ValidIssuer = "MealPlannerAPI",
					//ValidAudience = "PostmanTestingAudience",
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("oj2JAIT25AleN4G5HQIWEw=="))
				};
			});

			builder.Services.AddAuthorization(options =>
			{
				options.AddPolicy("YourPolicyNameHere",
									policy => policy.RequireClaim("YourClaimNameHere"));
			});
		}
	}
}
