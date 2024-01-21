using MealPlannerAPI;
using MealPlannerAPI.Database;
using MealPlannerAPI.Model;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        Configurer.ConfigureGraphQL(builder);
        Configurer.ConfigureAuthenticationAndAuthorization(builder);

        builder.Services.AddScoped<IAuthService, AuthService>();

        var logger = Configurer.ConfigureLogger(builder);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseAuthentication();
        //app.UseAuthorization();

        app.MapGraphQL();

        app.MapControllers();

        logger.LogInformation("API has been started");

        app.Run();
    }
}