namespace MovieManagement.Models.Index;

public class MoviesViewModel
{
  public int TotalPages { get; } = default!;
  public int TotalResults { get; } = default!;
  public int Page { get; set; } = default!;
  public List<MovieViewModel> Movies { get; set; } = new();

  public MoviesViewModel(Domain.Models.MovieList movieList)
  {
    TotalPages = movieList.TotalPages;
    TotalResults = movieList.TotalResults;
    Page = movieList.Page;

    foreach (var movie in movieList.Movies)
    {
      Movies.Add(new MovieViewModel(movie));
    }
  }

  public MoviesViewModel()
  {

  }
}
