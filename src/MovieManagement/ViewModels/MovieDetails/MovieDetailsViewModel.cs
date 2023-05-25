namespace MovieManagement.ViewModels.MovieDetails;

public class MovieDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public float Revenue { get; }
    public DateTime ReleaseDate { get; }
    public float Budget { get; }
    public string Description { get; }
    public bool IsAdult { get; }
    public string ImageUrl { get; }
    public IList<Genre> Genres { get; }
    public int VoteCount { get; }
    public double VoteAverage { get; }
    public int Length { get; }
    public string OriginalLanguage { get; }
    public string Status { get; }
    public string Homepage { get; }
    public IList<ProductionCompany> ProductionCompanies { get; }
    public IList<ProductionCountry> ProductionCountries { get; }
    public IList<SpokenLanguage> SpokenLanguages { get; }
    public MovieCreditsViewModel Credits { get; }

    public MovieDetailsViewModel(Movie movie, Credits credits)
    {
        Id = movie.Id;
        Title = movie.Title;
        Revenue = movie.Revenue;
        ReleaseDate = movie.ReleaseDate ?? new DateTime(1,1,1);
        Budget = movie.Budget;
        Description = movie.Description;
        IsAdult = movie.IsAdult;
        ImageUrl = !string.IsNullOrEmpty(movie.ImageUrl) ? movie.ImageUrl : "Images/MovieMissingPicture.png";
        Genres = movie.Genres;
        VoteCount = movie.VoteCount;
        VoteAverage = Math.Round(movie.VoteAverage, 2);
        Length = movie.Length;
        OriginalLanguage = !string.IsNullOrEmpty(movie.OriginalLanguage) ? movie.OriginalLanguage.ToUpper() : string.Empty;
        Homepage = movie.Homepage;
        Status = movie.Status;
        ProductionCompanies = movie.ProductionCompanies;
        ProductionCountries = movie.ProductionCountries;
        SpokenLanguages = movie.SpokenLanguages;
        Credits = new MovieCreditsViewModel(credits);
    }
}