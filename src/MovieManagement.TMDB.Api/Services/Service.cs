namespace MovieManagement.TMDB.Api.Services;
public class Service : IService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly string ApiKey;

    public Service(IOptions<ApiConfig> settings, JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = new HttpClient();
        _jsonSerializerOptions = jsonSerializerOptions;
        ApiKey = Constants.Variables.ApiPath + settings.Value.APIKey;
    }

    public async Task<T> GetAsync<T>(string endpoint)
    {
        var request = new HttpRequestMessage(HttpMethod.Get,
            Constants.Variables.MovieDatabaseUri + endpoint + ApiKey);
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
    }
}