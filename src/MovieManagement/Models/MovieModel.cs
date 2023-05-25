namespace MovieManagement.Models;

public class MovieModel
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public IList<GenreModel> Genres { get; set; } = default!;

    public MovieModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        PosterUrl = movie.ImageUrl;
        ReleaseDate = DateOnly.FromDateTime(movie.ReleaseDate);
        Genres = new List<GenreModel>();

        foreach (var genre in movie.Genres)
        {
            Genres.Add(new GenreModel(genre.Id, genre.Name));
        }
    }
}
