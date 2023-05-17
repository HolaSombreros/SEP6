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