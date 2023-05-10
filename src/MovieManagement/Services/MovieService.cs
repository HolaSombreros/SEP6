using ApiService = MovieManagement.TMDB.Api.Services;
namespace MovieManagement.Services;

public class MovieService : IMovieService
{
    private readonly ApiService.IMovieService _movieService;
    public MovieService(ApiService.IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    public async Task<Movie> GetMovieDetailsAsync(int id)
    {
        return await _movieService.GetMovieByIdAsync(id);
    }

    public async Task<Credits> GetMoviesCreditsAsync(int id)
    {
        return await _movieService.GetMovieCreditsAsync(id);
    }
}