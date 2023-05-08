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
        var movieDto = await _service.GetAsync<MovieDto>(_settings.Value.MoviePath + id);
        return _movieMapper.Map<MovieDto, Movie>(movieDto);
    }

    public async Task<MovieList> GetUpcomingMoviesAsync()
    {
        var upcomingMoviesDto = await _service.GetAsync<UpcomingDto>(_settings.Value.MoviePath + _settings.Value.UpcomingPath);
        return _movieMapper.Map<UpcomingDto, MovieList>(upcomingMoviesDto);
    }

    public async Task<MovieCredits> GetMovieCredits(int id)
    {
        var movieCreditsDto = await _service.GetAsync<MovieCreditsDto>(_settings.Value.MoviePath + id + _settings.Value.CreditsPath);
        return _movieMapper.Map<MovieCreditsDto, MovieCredits>(movieCreditsDto);
    }
}