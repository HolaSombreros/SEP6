﻿namespace MovieManagement.ViewModels.MovieDetails;

public class MovieDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public string Revenue { get; }
    public DateTime ReleaseDate { get; }
    public string Budget { get; }
    public string Description { get; }
    public bool IsAdult { get; }
    public string ImageUrl { get; }
    public string Genres { get; }
    public string VoteCount { get; }
    public string VoteAverage { get; }
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
        Revenue = movie.Revenue != 0 ? $"${movie.Revenue}" : string.Empty;
        ReleaseDate = movie.ReleaseDate;
        Budget = movie.Budget != 0 ? $"${movie.Budget}" : string.Empty;
        Description = movie.Description;
        IsAdult = movie.IsAdult;
        ImageUrl = !string.IsNullOrEmpty(movie.ImageUrl) ? movie.ImageUrl : "Images/MovieMissingPicture.png";
        Genres = GetGenresToString(movie.Genres);
        VoteCount = $"{movie.VoteCount:n0}";
        VoteAverage = Math.Round(movie.VoteAverage, 2).ToString(CultureInfo.CurrentCulture);
        Length = GetMovieLength(movie.Length);
        OriginalLanguage = !string.IsNullOrEmpty(movie.OriginalLanguage)
            ? movie.OriginalLanguage.ToUpper()
            : string.Empty;
        Homepage = movie.Homepage;
        Status = movie.Status;
        ProductionCompanies = movie.ProductionCompanies.Select(company => new ProductionCompanyViewModel(company))
            .ToList();
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
        if (length == 0)
        {
            return string.Empty;
        }

        return $"{length / 60}:{(length % 60):D2} hours";
    }
}