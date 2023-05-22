namespace MovieManagement.TMDB.Api.Services;

public class SearchService : ISearchService
{
    private readonly IMapper _movieMapper;
    private readonly IService _service;
    private readonly ApiConfig _settings;
    
    public SearchService(IService service, IMapper movieMapper, IOptions<ApiConfig> settings)
    {
        _service = service;
        _movieMapper = movieMapper;
        _settings = settings.Value;
    }
    
    public async Task<SearchAll> SearchAllAsync(string query, int page)
    {
        try
        {
            var searchResult = await _service.GetAsync<SearchAllListDto>(_settings.SearchPath + query + _settings.AndQueryBuilder + _settings.PagePath + page  + _settings.AndQueryBuilder);
            return MapMoviesAndPeople(searchResult);
        }
        catch
        {
            return new SearchAll();
        }
    }

    private SearchAll MapMoviesAndPeople(SearchAllListDto searchResult)
    {
        var result = _movieMapper.Map<SearchAllListDto, SearchAll>(searchResult);
        var uniqueMovies = searchResult.Results.Where(s =>  string.Equals(s.MediaType, MediaType.Movie.ToString(), StringComparison.OrdinalIgnoreCase)).GroupBy(m => new { m.ReleaseDate, m.Title })
            .Select(s => s.FirstOrDefault()).ToList()!;
        var uniquePeople = searchResult.Results.Where(r => string.Equals(r.MediaType, MediaType.Person.ToString(), StringComparison.OrdinalIgnoreCase)).ToList();
        var searchAllResult = new SearchAll
        {
            MovieResults = new List<SearchMovieResult>(),
            PersonResults = new List<SearchPersonResult>()
        };
        foreach (var movie in uniqueMovies.Select(result => _movieMapper.Map<SearchResultDto, SearchMovieResult>(result!)))
        {
            searchAllResult.MovieResults.Add(movie);
        }
        foreach (var person in uniquePeople.Select(result => _movieMapper.Map<SearchResultDto, SearchPersonResult>(result)))
        {
            searchAllResult.PersonResults.Add(person);
        }
        result.TotalResults = searchAllResult.MovieResults.Count + searchAllResult.PersonResults.Count;
        result.MovieResults = searchAllResult.MovieResults;
        result.PersonResults = searchAllResult.PersonResults;
        return result;
    }
}