namespace MovieManagement.ViewModels.MovieDetails;

public class MovieDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public string Revenue { get; }
    public string ReleaseDate { get; }
    public string Budget { get; }
    public string Description { get; }
    public bool IsAdult { get; }
    public string ImageUrl { get; }
    public string Genres { get; }
    public string VoteCount { get; }
    public double VoteAverage { get; }
    public string Length { get; }
    public string OriginalLanguage { get; }
    public string Status { get; }
    public string Homepage { get; }
    public IReadOnlyList<ProductionCompanyViewModel> ProductionCompanies { get; }
    public string ProductionCountries { get; }
    public string SpokenLanguages { get; }
    public MovieCreditsViewModel Credits { get; }


    public MovieDetailsViewModel(Movie movie, Credits credits)
    {
        Id = movie.Id;
        Title = movie.Title;
        Revenue = $"{movie.Revenue:C}";
        ReleaseDate = movie.ReleaseDate.ToString("dd/MM/yyyy");
        Budget = $"{movie.Budget:C}";
        Description = movie.Description;
        IsAdult = movie.IsAdult;
        ImageUrl = movie.ImageUrl;
        Genres = GetGenresToString(movie.Genres);
        VoteCount = $"{movie.VoteCount:n0}";
        VoteAverage = Math.Round(movie.VoteAverage, 2);
        Length = GetMovieLength(movie.Length);
        OriginalLanguage = movie.OriginalLanguage.ToUpper();
        Homepage = movie.Homepage;
        Status = movie.Status;
        ProductionCompanies = movie.ProductionCompanies.Select(company => new ProductionCompanyViewModel(company)).ToList();
        ProductionCountries = GetProductionCountriesToString(movie.ProductionCountries);
        SpokenLanguages = GetSpokenLanguagesToString(movie.SpokenLanguages);
        Credits = new MovieCreditsViewModel(credits);
    }

    private string GetGenresToString(IList<Genre> genres)
    {
        if (!genres.Any())
        {
            return "No genres available for this movie";
        }

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
        if (!productionCountries.Any())
        {
            return "No production countries available for this movie";
        }

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
        if (!spokenLanguages.Any())
        {
            return "No spoken languages available for this movie";
        }

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