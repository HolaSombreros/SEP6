using MovieManagement.ViewModels.Search;

namespace MovieManagement.Components;

public partial class Search : ComponentBase
{
    private SearchViewModel searchModel = new();

    private void MakeSure()
    {
        NavigationManager.NavigateTo($"/search-results/{searchModel.SearchInput}");
        searchModel = new();
    }
}
