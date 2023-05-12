namespace MovieManagement.Services;

public interface IMovieService
{
    Task<Movie> GetMovieDetailsAsync(int id);
    Task<Credits> GetMoviesCreditsAsync(int id);
}