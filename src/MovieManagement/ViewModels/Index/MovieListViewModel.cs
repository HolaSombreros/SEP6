namespace MovieManagement.ViewModels.Index;

public class MovieListViewModel
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    [Required(ErrorMessage = "Please enter a title")]
    [MinLength(1, ErrorMessage = "The title has to be at least {1} characters")]
    public string Title { get; set; } = default!;

    public MovieListViewModel() { }
    
    public MovieListViewModel(MovieListDto listDto)
    {
        Id = listDto.Id;
        UserId = listDto.UserId;
        Title = listDto.Title;
    }
}