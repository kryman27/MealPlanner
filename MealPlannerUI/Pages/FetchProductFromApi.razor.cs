using MealPlannerUI.Data;

namespace MealPlannerUI.Pages
{
    public partial class FetchProductFromApi
    {
        private ProductInfo[]? prodInfForUI;
        private WeatherForecast[]? forecasts;
        protected override async Task OnInitializedAsync()
        {
            //forecasts = await ForecastService.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));
            prodInfForUI = await ProdService.GetProductsInfo();
        }
    }
}