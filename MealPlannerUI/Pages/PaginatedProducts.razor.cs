using ModelsLib.Model;

namespace MealPlannerUI.Pages;

public partial class PaginatedProducts
{
    private List<Product> prodInfForUI;
    private int _productsNumber = 10;
    private int _pageNumber = 1;
    private int totalPageCount;

    public event Action<int> PageNumberChanged;
    public event Action<int> ProductsNumberChanged;

    public int ProductsNumber
    {
        get => _productsNumber;

        set
        {
            if(_productsNumber != value)
            {
                _productsNumber = value;
                ProductsNumberChanged?.Invoke(_productsNumber);
                GetProducts();
            }
        }
    }

    public int PageNumber
    {
        get => _pageNumber;

        set
        {
            if (_pageNumber != value)
            {
                _pageNumber = value;
                PageNumberChanged?.Invoke(_pageNumber);
                GetProducts();
            }
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var result = await ProdService.GetPaginatedProducts(_productsNumber, _pageNumber);
        prodInfForUI = result.DataModel.ToList();
        totalPageCount = Convert.ToInt32(result.HeaderInfoValue);
    }

    
    private async Task GetProducts()
    {
        try
        {
            prodInfForUI.Clear();
            var prod = await ProdService.GetPaginatedProducts(ProductsNumber, PageNumber);
            totalPageCount = Convert.ToInt32(prod.HeaderInfoValue);
            if (prod.DataModel.Count != 0)
            {
                foreach (var item in prod.DataModel)
                {
                    prodInfForUI.Add(item);
                }
            }
            else
            {
                prodInfForUI.Add(new Product { ProductName = "Product was not found" });
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        StateHasChanged();
    }
}