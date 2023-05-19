namespace MovieManagement.TMDB.Api.Services;

public class StatisticsService : IStatisticsService
{
    private readonly IMapper _movieMapper;
    private readonly IService _service;
    private readonly ApiConfig _settings;
    
    public StatisticsService(IService service, IMapper movieMapper, IOptions<ApiConfig> settings)
    {
        _service = service;
        _movieMapper = movieMapper;
        _settings = settings.Value;
    }

    public async Task<MovieList> GetMostRatedMoviesByReleaseYear(int year, int page)
    {
        try
        {
            var movieListDto = await _service.GetAsync<MovieListDto>(_settings.DiscoverPath + "movie?include_adult=false&include_video=false&primary_release_year=" +
                year + "&language=en-US&page=" + page + "&sort_by=vote_count.desc" +
            _settings.AndQueryBuilder);
            return _movieMapper.Map<MovieListDto, MovieList>(movieListDto);
        }
        catch
        {
            return new MovieList();
        }
    }
}