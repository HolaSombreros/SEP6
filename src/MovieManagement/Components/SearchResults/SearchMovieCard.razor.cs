namespace MovieManagement.Components.SearchResults;

public partial class SearchMovieCard : ComponentBase
{
    [Parameter]
    public SearchMovieViewModel Movie { get; set; } = default!;

    private void ShowMovieDetails(long movieId)
    {
        NavigationManager.NavigateTo($"/movies/{movieId}");
    }
}
