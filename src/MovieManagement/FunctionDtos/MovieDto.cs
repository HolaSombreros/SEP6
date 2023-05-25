namespace MovieManagement.FunctionDtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }
    public IList<GenreDto> Genres { get; set; } = new List<GenreDto>();

    public MovieDto(MovieModel movieModel)
    {
        MovieId = movieModel.Id;
        Title = movieModel.Title;
        PosterUrl = movieModel.PosterUrl;
        ReleaseDate = movieModel.ReleaseDate?.ToString("yyyy-MM-dd");

        foreach (var genre in movieModel.Genres)
        {
            Genres.Add(new(genre.Id, genre.Name));
        }
    }

    public MovieDto(MovieViewModel movieModel)
    {
        MovieId = movieModel.Id;
        Title = movieModel.Title;
        PosterUrl = movieModel.PosterPath;
        ReleaseDate = movieModel.ReleaseDate.ToString("yyyy-MM-dd");

        foreach (var genre in movieModel.Genres)
        {
            Genres.Add(new(genre.Id, genre.Name));
        }
    }

    [JsonConstructor]
    public MovieDto()
    {
    }
}
