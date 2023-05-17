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
            var movieDto = await _service.GetAsync<MovieDto>(_settings.MoviePath + id + _settings.QueryBuilder);
            return _movieMapper.Map<MovieDto, Movie>(movieDto);
        }
        catch
        {
            return new Movie();
        }
    }

    public async Task<MovieList> GetMovieListAsync(ListType listType, int page)
    {
        try
        {
            var pagePath = _settings.QueryBuilder + _settings.PagePath + page + _settings.AndQueryBuilder;
            var movieList = listType switch
            {
                ListType.Upcoming => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.UpcomingPath +
                                                                           pagePath),
                ListType.TopRated => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.TopRatedPath +
                                                                           pagePath),
                ListType.InTheater => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.InTheatrePath +
                                                                           pagePath),
                ListType.Popular => await _service.GetAsync<MovieListDto>(_settings.MoviePath + _settings.PopularPath +
                                                                           pagePath),
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

    public async Task<SearchAll> SearchAll(string query)
    {
        try
        {
            var searchResult = await _service.GetAsync<SearchAllListDto>(_settings.SearchPath + query + _settings.AndQueryBuilder);
            var uniqueMovies = searchResult.Results.Where(s =>  string.Equals(s.MediaType, MediaType.Movie.ToString(), StringComparison.OrdinalIgnoreCase)).GroupBy(m => new { m.ReleaseDate, m.Title })
                .Select(s => s.FirstOrDefault()).ToList()!;
            var uniquePeople = searchResult.Results.Where(r => string.Equals(r.MediaType, MediaType.Person.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
            searchResult.Results = uniqueMovies.Concat(uniquePeople).ToList()!;
            searchResult.TotalResults = searchResult.Results.Count;
            return _movieMapper.Map<SearchAllListDto, SearchAll>(searchResult);
        }
        catch
        {
            return new SearchAll();
        }
    }
}