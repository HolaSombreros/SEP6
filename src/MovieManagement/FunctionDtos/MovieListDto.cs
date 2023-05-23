namespace MovieManagement.FunctionDtos;

public class MovieListDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = default!;
    public List<MovieDto> Movies { get; set; } = default!;

    public MovieListDto(MovieListViewModel list)
    {
        Id = list.Id;
        UserId = list.UserId;
        Title = list.Title;
        Movies = list.Movies.Select(movie => new MovieDto(movie)).ToList();
    }
    
    [JsonConstructor]
    public MovieListDto()
    {
    }
}