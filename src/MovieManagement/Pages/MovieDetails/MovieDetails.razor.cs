namespace MovieManagement.Pages.MovieDetails;

public partial class MovieDetails : ComponentBase
{
    [Parameter] 
    public int Id { get; set; }
    private MovieDetailsViewModel _details = default!;
    private string _message = "Loading...";
    private MovieModel movieModel = default!;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            var credits = await MovieService.GetMovieCreditsAsync(Id);
            var movie = await MovieService.GetMovieByIdAsync(Id);
            if (movie.Id != 0)
            {
                _details = new MovieDetailsViewModel(
                    movie: movie,
                    credits: credits);
                movieModel = new MovieModel(movie);
            }
            else
            {
                _message = "No movie found with this id";
            }
        }
        catch (Exception)
        {
            _details = default!;
        }
    }

    private async Task OpenMovieHomePage()
    {
        await JSRuntime.InvokeVoidAsync("open", _details.Homepage, "_blank");
    }
}