namespace MovieManagement.Functions.Dtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string? Title { get; set; }
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }
    public IList<GenreDto>? Genres { get; set; }
}