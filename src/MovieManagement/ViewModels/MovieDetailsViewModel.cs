namespace MovieManagement.ViewModels;

public class MovieDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public int Revenue { get; }
    public DateTime ReleaseDate { get; }
    public int Budget { get; }
    public string Description { get; }
    public bool IsAdult { get; }
    public string ImageUrl { get; }
    public string Genres { get; }
    public int VoteCount { get; }
    public double VoteAverage { get; }
    public string Length { get; }
    public double Popularity { get; }
    public string OriginalLanguage { get; }
    public string Status { get; }
    public string Homepage { get; }
    public IReadOnlyList<ProductionCompanyViewModel> ProductionCompanies { get; }
    public string ProductionCountries { get; }
    public string SpokenLanguages { get; }
    public IReadOnlyList<MovieDetailsCrewViewModel> Crew { get; }
    public IReadOnlyList<MovieDetailsCastViewModel> Cast { get; }


    public MovieDetailsViewModel(Movie movie, IList<Cast> cast, IList<Crew> crew)
    {
        Id = movie.Id;
        Title = movie.Title;
        Revenue = movie.Revenue;
        ReleaseDate = movie.ReleaseDate;
        Budget = movie.Budget;
        Description = movie.Description;
        IsAdult = movie.IsAdult;
        ImageUrl = movie.ImageUrl;
        Genres = GetGenresToString(movie.Genres);
        VoteCount = movie.VoteCount;
        VoteAverage = movie.VoteAverage;
        Length = GetMovieLength(movie.Length);
        Popularity = movie.Popularity;
        OriginalLanguage = movie.OriginalLanguage;
        Homepage = movie.Homepage;
        Status = movie.Status;
        ProductionCompanies = movie.ProductionCompanies.Select(company => new ProductionCompanyViewModel(company))
            .ToList();
        ProductionCountries = GetProductionCountriesToString(movie.ProductionCountries);
        SpokenLanguages = GetSpokenLanguagesToString(movie.SpokenLanguages);
        Cast = cast.Select(person => new MovieDetailsCastViewModel(person)).ToList();
        Crew = crew.Select(person => new MovieDetailsCrewViewModel(person)).ToList();
    }

    private string GetGenresToString(IList<Genre> genres)
    {
        if (!genres.Any())
        {
            return "No genres on this movie";
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
            return "No genres on this movie";
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
            return "No genres on this movie";
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
        return $"{length / 60}:{(length % 60).ToString("D2")} hours";
    }
}