namespace MovieManagement.Domain.Models.TMDB;

public class SearchAll
{
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
    public List<SearchMovieResult> MovieResults { get; set; } = default!;
    public List<SearchPersonResult> PersonResults { get; set; } = default!;
    public int Page { get; set; }
}