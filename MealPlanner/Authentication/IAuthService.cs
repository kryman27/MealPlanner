namespace MealPlannerAPI.Authentication
{
    public interface IAuthService
    {
        string GenerateJwtToken(string username);
    }
}
