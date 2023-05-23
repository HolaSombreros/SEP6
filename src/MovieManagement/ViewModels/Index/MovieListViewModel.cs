namespace MovieManagement.ViewModels.Index;

public class MovieListViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [Required(ErrorMessage = "Please enter a title")]
    [MinLength(1, ErrorMessage = "The title has to be at least {1} characters")]
    public string Title { get; set; } = default!;
    public bool HasMovie { get; set; }
    public List<MovieViewModel> Movies { get; set; }

    public MovieListViewModel()
    {
        Movies = new List<MovieViewModel>();
    }
    
    public MovieListViewModel(MovieListDto listDto)
    {
        Id = listDto.Id;
        UserId = listDto.UserId;
        Title = listDto.Title;
        Movies = listDto.Movies.Select(movie => new MovieViewModel(movie)).ToList();
    }
}