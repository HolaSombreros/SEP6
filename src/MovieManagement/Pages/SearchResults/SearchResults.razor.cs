namespace MovieManagement.Pages.SearchResults;

public partial class SearchResults : ComponentBase
{
    [Parameter]
    public string SearchInput { get; set; } = default!;

    
    private const int serviceMaxCallCount = 5;

    protected override async Task OnInitializedAsync()
    {
        // Call the SearchService 5 times?
    }
}
