namespace MealPlannerAPI
{
	public interface IAuthService
	{
		string GenerateJwtToken(string username);
	}
}
