namespace MovieManagement.Pages.MovieDetails;

public partial class MovieDetails : ComponentBase
{
    [Parameter]
    public int Id { get; set; }
    private MovieDetailsViewModel _details = default!;
    private string _message = "Loading...";

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
        for (var i = 0; i < genres.Count - 1; i++)
        {
            genresToString += $"{genres[i].Name}, ";
        }

        genresToString += genres[^1].Name;
        return genresToString;
    }

    private string GetProductionCountriesToString(IList<ProductionCountry> productionCountries)
    {
        var productionCountriesToString = "";
        for (var i = 0; i < productionCountries.Count - 1; i++)
        {
            productionCountriesToString += $"{productionCountries[i].Name}, ";
        }

        productionCountriesToString += productionCountries[^1].Name;
        return productionCountriesToString;
    }

    private string GetSpokenLanguagesToString(IList<SpokenLanguage> spokenLanguages)
    {
        var spokenLanguagesToString = "";
        for (var i = 0; i < spokenLanguages.Count - 1; i++)
        {
            spokenLanguagesToString += $"{spokenLanguages[i].Name}, ";
        }

        spokenLanguagesToString += spokenLanguages[^1].Name;
        return spokenLanguagesToString;
    }

    private string GetMovieLength(int length)
    {
        return $"{length / 60}:{(length % 60):D2} hours";
    }
}