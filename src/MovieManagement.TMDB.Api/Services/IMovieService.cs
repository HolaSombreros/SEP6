namespace MovieManagement.TMDB.Api.Services;

public interface IMovieService
{
    public Task<Movie> GetMovieByIdAsync(int id);
    public Task<MovieList> GetUpcomingMoviesAsync(ListType listType);
    public Task<Credits> GetMovieCreditsAsync(int id);
}