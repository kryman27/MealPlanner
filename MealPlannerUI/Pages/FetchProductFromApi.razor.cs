using MealPlannerUI.Data;

namespace MealPlannerUI.Pages
{
    public partial class FetchProductFromApi
    {
        private ProductInfo[]? prodInfForUI;
        protected override async Task OnInitializedAsync()
        {
            prodInfForUI = await ProdService.GetProductsInfo();
        }
    }
}