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

    public async Task<MovieList> GetMostRatedMoviesByReleaseYearAsync(int year, int page)
    {
        try
        {
            var queriedYear = year <= 0 ? "" : $"&primary_release_year={year}";
            var endpoint = $"{_settings.DiscoverPath}movie?include_adult=false&include_video=false{queriedYear}&language=en-US&page={page}&sort_by=vote_count.desc{_settings.AndQueryBuilder}";
            var movieListDto = await _service.GetAsync<MovieListDto>(endpoint);
            return _movieMapper.Map<MovieListDto, MovieList>(movieListDto);
        }
        catch
        {
            return new MovieList();
        }
    }

    public async Task<MovieList> GetMoviesWithHighestRevenueByYearAsync(int year, int page)
    {
        try
        {
            var queriedYear = year <= 0 ? "" : $"&primary_release_year={year}";
            var endpoint = $"{_settings.DiscoverPath}movie?include_adult=false&include_video=false{queriedYear}&language=en-US&page={page}&sort_by=revenue.desc{_settings.AndQueryBuilder}";
            var movieListDto = await _service.GetAsync<MovieListDto>(endpoint);
            return _movieMapper.Map<MovieListDto, MovieList>(movieListDto);
        }
        catch
        {
            return new MovieList();
        }
    }

    public async Task<Credits> GetMostPopularMovieAsync(int personId)
    {
        try
        {
            var personCreditsDto = await _service.GetAsync<CreditsDto>(_settings.PersonPath + personId + _settings.MovieCredits + _settings.QueryBuilder);
            var sortedCast = personCreditsDto.Cast.OrderByDescending(c => c.Popularity).ToList();
            var sortedCrew = personCreditsDto.Crew.OrderByDescending(c => c.Popularity).ToList();
            var sortedCredits = new CreditsDto
            {
                Cast = sortedCast,
                Crew = sortedCrew
            };
            return _movieMapper.Map<CreditsDto, Credits>(sortedCredits);

        }
        catch
        {
            return new Credits();
        }
    }
}