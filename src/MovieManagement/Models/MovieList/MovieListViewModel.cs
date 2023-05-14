using MovieManagement.Models.Index;

namespace MovieManagement.Models.MovieList;

public class MovieListViewModel
{
    public string Id { get; set; } = default!;
    public string? Name { get; set; }
    public MoviesViewModel MovieList { get; set; } = default!;
}
