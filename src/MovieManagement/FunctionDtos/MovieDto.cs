namespace MovieManagement.FunctionDtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }

    public MovieDto(MovieModel movieModel)
    {
        MovieId = movieModel.Id;
        Title = movieModel.Title;
        PosterUrl = movieModel.PosterUrl;
        ReleaseDate = movieModel.ReleaseDate?.ToString("yyyy-MM-dd");
    }

    [JsonConstructor]
    public MovieDto()
    {
    }
}
