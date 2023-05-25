namespace MovieManagement.Models;

public class MovieModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public IList<Genre> Genres { get; set; } = new List<Genre>();

    public MovieModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterUrl = movie.ImageUrl;
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
        Genres = movie.Genres;
    }
}
