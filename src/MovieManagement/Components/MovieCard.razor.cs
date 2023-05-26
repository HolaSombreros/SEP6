namespace MovieManagement.Components;

public partial class MovieCard : ComponentBase
{
    [Parameter]
    public MovieViewModel Movie { get; set; } = default!;

    [Parameter]
    public bool ShowVoteCount { get; set; }

    private void ShowMovieDetails(long movieId)
    {
        NavigationManager.NavigateTo($"/movies/{movieId}");
    }
}