namespace MovieManagement.TMDB.Api.Services;

public interface IMovieService
{
    public Task<Movie> GetMovieByIdAsync(int id);
}