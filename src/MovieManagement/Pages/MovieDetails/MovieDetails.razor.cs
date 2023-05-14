namespace MovieManagement.Pages.MovieDetails;

public partial class MovieDetails : ComponentBase
{
    [Parameter] public int Id { get; set; }
    private MovieDetailsViewModel _details = default!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var credits = await MovieService.GetMovieCreditsAsync(Id);
            _details = new MovieDetailsViewModel(
                movie: await MovieService.GetMovieByIdAsync(Id),
                credits: credits);
        }
        catch (Exception exception)
        {
            _details = default!;
        }
    }
}