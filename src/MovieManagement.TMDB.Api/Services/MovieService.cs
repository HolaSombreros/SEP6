namespace MovieManagement.TMDB.Api.Services;

public class MovieService : IMovieService
{
    private readonly IMapper _movieMapper;
    private readonly IService _service;
    private readonly ApiConfig _settings;
    public MovieService(IService service, IMapper movieMapper, IOptions<ApiConfig> settings)
    {
        _service = service;
        _movieMapper = movieMapper;
        _settings = settings.Value;
    }
    
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        try
        {
            var movieDto = await _service.GetAsync<MovieDto>(_settings.MoviePath + id);
            return _movieMapper.Map<MovieDto, Movie>(movieDto);
        }
        catch
        {
            return new Movie();
        }
    }

    public async Task<MovieList> GetUpcomingMoviesAsync(ListType listType)
    {
        try
        {
            var movieList = listType switch
            {
                ListType.UPCOMING => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.UpcomingPath +
                                                                           _settings.QueryBuilder),
                ListType.POPULAR => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.PopularPath +
                                                                          _settings.QueryBuilder),
                ListType.LATEST => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.LatestPath +
                                                                         _settings.QueryBuilder),
                _ => new MovieListDto()
            };
            return _movieMapper.Map<MovieListDto, MovieList>(movieList);
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
            var movieCreditsDto = await _service.GetAsync<CreditsDto>(_settings.MoviePath + id + _settings.CreditsPath + _settings.QueryBuilder);
            return _movieMapper.Map<CreditsDto, Credits>(movieCreditsDto);
        }
        catch
        {
            return new Credits();
        }
    }
}