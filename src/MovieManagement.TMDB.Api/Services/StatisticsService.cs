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
             var endpoint = _settings.DiscoverPath +
                            _settings.MoviePath + "?include_adult=false&include_video=false&primary_release_year=" +
                            year + "&language=en-US&page=" + page + "&sort_by=vote_count.desc" +
                            _settings.AndQueryBuilder;
             //var movieListDto = await _service.GetAsync<MovieListDto>(endpoint);

            var client = new HttpClient();
            var movieListDto = new MovieListDto();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://api.themoviedb.org/3/discover/movie?include_adult=false&include_video=false&primary_release_year=2022&language=en-US&page=1&sort_by=vote_count.desc&api_key=ea9636733ed6b1f42e788b4147b59d6a"),
                Headers =
                {
                    { "accept", "application/json" }
                }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                movieListDto = JsonSerializer.Deserialize<MovieListDto>(body);
            }
            return _movieMapper.Map<MovieListDto, MovieList>(movieListDto);
            
        }
        catch
        {
            return new MovieList();
        }
    }
}