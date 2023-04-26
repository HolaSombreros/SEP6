namespace MovieManagement.TMDB.Api.Services;

public class MovieService : IMovieService
{
    private readonly HttpClient _httpClient;
    private readonly IMapper _movieMapper;
    private readonly string ApiKey;
    private readonly IConfiguration _configuration;
    private readonly JsonSerializerOptions _jsonSerializerOptions;

    public MovieService(IMapper movieMapper, IConfiguration configuration, JsonSerializerOptions jsonSerializerOptions)
    {
        _configuration = configuration;
        _jsonSerializerOptions = jsonSerializerOptions;
        _movieMapper = movieMapper;
        _httpClient = new HttpClient();
        ApiKey += Constants.Variables.ApiPath + _configuration["TheMovieDatabase:APIKey"];
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