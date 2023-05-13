namespace MovieManagement.Services;

public class MovieService : IMovieService
{
    private readonly IMovieService _movieService;
    public MovieService(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    public async Task<Movie> GetMovieDetailsAsync(int id)
    {
        return await _movieService.GetMovieDetailsAsync(id);
    }

    public async Task<Credits> GetMoviesCreditsAsync(int id)
    {
        return await _movieService.GetMoviesCreditsAsync(id);
    }
}