namespace MovieManagement.ViewModels.Index;

public class MoviesViewModel
{
    public int TotalPages { get; }
    public int TotalResults { get; }
    public int Page { get; set; } 
    public List<MovieViewModel> Movies { get; }

    public MoviesViewModel(MovieList movieList)
    {
        TotalPages = movieList.TotalPages;
        TotalResults = movieList.TotalResults;
        Page = movieList.Page;
        Movies = new List<MovieViewModel>();

        if (movieList.Movies != null)
        {
            foreach (var movie in movieList.Movies)
            {
                Movies.Add(new MovieViewModel(movie));
            }
        }
    }
}
