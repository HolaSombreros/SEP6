namespace MovieManagement.TMDB.Api.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _movieMapper;
    private readonly IService _service;

    public MovieService(IService service, IMapper movieMapper)
    {
        _service = service;
        _movieMapper = movieMapper;
    }
    
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movieDto = await _service.GetAsync<MovieDto>(Constants.Variables.MoviePath + id);
        return _movieMapper.Map<MovieDto, Movie>(movieDto);
    }

    public async Task<MovieList> GetUpcomingMoviesAsync()
    {
        var upcomingMoviesDto = await _service.GetAsync<UpcomingDto>(Constants.Variables.MoviePath + Constants.Variables.UpcomingPath);
        return _movieMapper.Map<UpcomingDto, MovieList>(upcomingMoviesDto);
    }
}