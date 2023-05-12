namespace MovieManagement.Domain.Models.TMDB;

public class SearchResult
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public MediaType MediaType { get; set; } = default!;
    public string ProfilePath { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string PosterPath { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
}