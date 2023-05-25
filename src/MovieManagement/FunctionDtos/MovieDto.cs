namespace MovieManagement.FunctionDtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }
    public IList<Genre> Genres { get; set; } = default!;

    public MovieDto(MovieModel movieModel)
    {
        MovieId = movieModel.Id;
        Title = movieModel.Title;
        PosterUrl = movieModel.PosterUrl;
        ReleaseDate = movieModel.ReleaseDate?.ToString("yyyy-MM-dd");
        Genres = movieModel.Genres;
    }

    public MovieDto(MovieViewModel movieModel)
    {
        MovieId = movieModel.Id;
        Title = movieModel.Title;
        PosterUrl = movieModel.PosterPath;
        ReleaseDate = movieModel.ReleaseDate.ToString("yyyy-MM-dd");
        Genres = movieModel.Genres;
    }

    [JsonConstructor]
    public MovieDto()
    {
    }
}
