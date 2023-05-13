namespace MovieManagement.Pages.MovieDetails;

public partial class MovieDetails : ComponentBase
{
    [Parameter] public int Id { get; set; }
    private MovieDetailsViewModel _details = default!;

    protected override async Task OnInitializedAsync()
    {
        var credits = await MovieService.GetMoviesCreditsAsync(Id);
        _details = new MovieDetailsViewModel(
            movie: await MovieService.GetMovieDetailsAsync(Id),
            credits: credits);
    }
}