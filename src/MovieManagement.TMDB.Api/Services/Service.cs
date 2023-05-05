namespace MovieManagement.TMDB.Api.Services;
public class Service : IService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly string? _apiKey;
    private readonly IOptions<ApiConfig> _settings;

    public Service(IOptions<ApiConfig> settings, JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = new HttpClient();
        _settings = settings;
        _jsonSerializerOptions = jsonSerializerOptions;
        _apiKey = settings.Value.ApiKey;
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            _settings.Value.MovieDatabaseUri + endpoint + _apiKey);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
    }
}