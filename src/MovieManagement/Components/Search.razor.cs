using MovieManagement.ViewModels.Search;

namespace MovieManagement.Components;

public partial class Search : ComponentBase
{
    private SearchInputViewModel searchModel = new();

    private void MakeSure()
    {
        NavigationManager.NavigateTo($"/search-results/{searchModel.SearchInput}", true);
        searchModel = new();
    }
}
