namespace MovieManagement.Components;

public partial class Search : ComponentBase
{
    private SearchInputViewModel searchModel = new();

    private void MakeSearch()
    {
        NavigationManager.NavigateTo($"/search-results/{searchModel.SearchInput}", true);
        searchModel = new();
    }
}
