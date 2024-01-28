using ModelsLib.Model;

namespace MealPlannerUI.Pages
{
    public partial class AllProducts
    {
        private List<Product>? prodInfForUI;
        protected override async Task OnInitializedAsync()
        {
            prodInfForUI = await ProdService.GetProductsInfo();
        }
    }
}