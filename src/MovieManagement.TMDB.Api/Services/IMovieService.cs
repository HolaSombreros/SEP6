namespace MovieManagement.TMDB.Api.Services;

public interface IMovieService
{
    public Task<Movie> GetMovieByIdAsync(int id);
    public Task<MovieList> GetMovieListAsync(ListType listType, int page);
    public Task<Credits> GetMovieCreditsAsync(int id);
    public Task<SearchAll> SearchAll(string query);
}