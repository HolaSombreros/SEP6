namespace MovieManagement.Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int Revenue { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Budget { get; set; }
    public string Description { get; set; } = default!;
    public bool IsAdult { get; set; }
    public string ImageUrl { get; set; } = default!;
    public IList<Genre> Genres { get; set; } = default!;
    public int VoteCount { get; set; }
    public double VoteAverage { get; set; }
    public int Length { get; set; }
    public double Popularity { get; set; }
    public string OriginalLanguage { get; set; } = default!;
    public string Status { get; set; } = default!;
    public string Homepage { get; set; } = default!;
    public IList<ProductionCompany> ProductionCompanies { get; set; } = default!;
    public IList<ProductionCountry> ProductionCountries { get; set; } = default!;
    public IList<SpokenLanguage> SpokenLanguages { get; set; } = default!;
}