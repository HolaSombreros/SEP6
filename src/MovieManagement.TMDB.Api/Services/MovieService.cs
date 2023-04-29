namespace MovieManagement.TMDB.Api.Services;

public class MovieService : IMovieService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _movieMapper;
    private readonly string ApiKey;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public MovieService(IOptions<ApiConfig> settings, IMapper movieMapper, JsonSerializerOptions jsonSerializerOptions)
    {
        _jsonSerializerOptions = jsonSerializerOptions;
        _movieMapper = movieMapper;
        _httpClient = new HttpClient();
        ApiKey = Constants.Variables.ApiPath + settings.Value.APIKey;
    }


    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            Constants.Variables.MovieDatabaseUri + Constants.Variables.MoviePath + id + ApiKey);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var result = JsonSerializer.Deserialize<MovieDto>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions);
        var movie = _movieMapper.Map<MovieDto, Movie>(result);
        return movie;
    }
}