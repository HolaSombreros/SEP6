namespace MovieManagement.Domain.Models.TMDB;

public class SearchAll
{
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
    public List<SearchResult> Results { get; set; } = default!;
    public int Page { get; set; }
}