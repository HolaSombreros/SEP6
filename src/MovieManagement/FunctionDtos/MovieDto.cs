namespace MovieManagement.FunctionDtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string PosterUrl { get; set; }
    public string ReleaseDate { get; set; }

    public MovieDto(MovieDetailsViewModel movieDetailsViewModel)
    {
        MovieId = movieDetailsViewModel.Id;
        Title = movieDetailsViewModel.Title;
        PosterUrl = movieDetailsViewModel.ImageUrl;
        ReleaseDate = movieDetailsViewModel.ReleaseDate.ToString("yyyy-MM-dd");
    }

    [JsonConstructor]
    public MovieDto()
    {
    }
}
