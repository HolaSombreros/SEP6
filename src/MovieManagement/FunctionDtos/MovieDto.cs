namespace MovieManagement.FunctionDtos;

public class MovieDto
{
    public int MovieId { get; set; }
    public string Title { get; set; } = default!;
    public string? PosterUrl { get; set; }
    public string? ReleaseDate { get; set; }

    public MovieDto(MovieDetailsViewModel movieViewModel)
    {
        MovieId = movieViewModel.Id;
        Title = movieViewModel.Title;
        PosterUrl = movieViewModel.ImageUrl;
        ReleaseDate = movieViewModel.ReleaseDate;
    }
}
