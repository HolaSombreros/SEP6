namespace MovieManagement.FunctionDtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string PosterUrl { get; set; } = default!;
    public string ReleaseDate { get; set; } = default!;

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
