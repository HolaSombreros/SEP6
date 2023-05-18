namespace MovieManagement.Components.SearchResults;

public partial class SearchPersonCard : ComponentBase
{
    [Parameter]
    public SearchPersonViewModel Person { get; set; } = default!;

    private void ShowPersonDetails(long id)
    {
        NavigationManager.NavigateTo($"/people/{id}");
    }
}
