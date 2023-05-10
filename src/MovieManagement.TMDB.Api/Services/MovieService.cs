namespace MovieManagement.TMDB.Api.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _movieMapper;
    private readonly IService _service;
    private readonly IOptions<ApiConfig> _settings;
    public MovieService(IService service, IMapper movieMapper, IOptions<ApiConfig> settings)
    {
        _service = service;
        _movieMapper = movieMapper;
        _settings = settings;
    }
    
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        try
        {
            var movieDto = await _service.GetAsync<MovieDto>(_settings.Value.MoviePath + id);
            return _movieMapper.Map<MovieDto, Movie>(movieDto);
        }
        catch
        {
            return new Movie();
        }
    }

    public async Task<MovieList> GetUpcomingMoviesAsync()
    {
        try
        {
            var upcomingMoviesDto = await _service.GetAsync<MovieListDto>(_settings.Value.MoviePath + _settings.Value.UpcomingPath);
            return _movieMapper.Map<MovieListDto, MovieList>(upcomingMoviesDto);
        }
        catch
        {
            return new MovieList();
        }
    }

    public async Task<Credits> GetMovieCreditsAsync(int id)
    {
        try
        {
            var movieCreditsDto = await _service.GetAsync<CreditsDto>(_settings.Value.MoviePath + id + _settings.Value.CreditsPath);
            return _movieMapper.Map<CreditsDto, Credits>(movieCreditsDto);
        }
        catch(Exception e)
        {
            return new Credits();
        }
    }
}