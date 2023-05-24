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
            var movie = await CombinedRatingService.GetMovieByIdAsync(Id);
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
    
    private string GetGenresToString(IList<Genre> genres)
    {
        var genresToString = "";
        var count = genres.Count;
        for (var i = 0; i < count - 1; i++)
        {
            genresToString += $"{genres[i].Name}, ";
        }

        genresToString += genres[count - 1].Name;
        return genresToString;
    }

    private string GetProductionCountriesToString(IList<ProductionCountry> productionCountries)
    {
        var productionCountriesToString = "";
        var count = productionCountries.Count;
        for (var i = 0; i < count - 1; i++)
        {
            productionCountriesToString += $"{productionCountries[i].Name}, ";
        }

        productionCountriesToString += productionCountries[count - 1].Name;
        return productionCountriesToString;
    }

    private string GetSpokenLanguagesToString(IList<SpokenLanguage> spokenLanguages)
    {
        var spokenLanguagesToString = "";
        var count = spokenLanguages.Count;
        for (var i = 0; i < count - 1; i++)
        {
            spokenLanguagesToString += $"{spokenLanguages[i].Name}, ";
        }

        spokenLanguagesToString += spokenLanguages[count - 1].Name;
        return spokenLanguagesToString;
    }

    private string GetMovieLength(int length)
    {
        return $"{length / 60}:{(length % 60):D2} hours";
    }
}