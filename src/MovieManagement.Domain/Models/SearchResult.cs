namespace MovieManagement.Domain.Models;

public class SearchResult
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string MediaType { get; set; } = default!;
    public string ProfilePath { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string PosterPath { get; set; } = default!;
    public DateTime ReleaseDate { get; set; }
}