namespace MovieManagement.Domain.Models.TMDB;

public class SearchMovieResult
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterPath { get; set; }
    public DateTime? ReleaseDate { get; set; }
}