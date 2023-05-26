namespace MovieManagement.Services;

public class AzureService : IAzureService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly AzureFunctionsConfig _settings;

    public AzureService(IOptions<AzureFunctionsConfig> settings, IHttpClientFactory clientFactory,
        JsonSerializerOptions jsonSerializerOptions)
    {
        _httpClient = clientFactory.CreateClient();
        _settings = settings.Value;
        _jsonSerializerOptions = jsonSerializerOptions;
    }

    public async Task<T> GetFromRouteAsync<T>(string endpoint, object id)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            _settings.AzureFunctionUri +
            endpoint +
            $"/{id}");
        var response = await _httpClient.SendAsync(request);
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
    }

    public async Task<T?> GetAsync<T>(string endpoint, object body, int? page = null)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Get,
            _settings.AzureFunctionUri +
            endpoint +
            (page != null ? (_settings.QueryBuilder + _settings.PagePath + page) : ""));
        request.Content = JsonContent.Create(body);
        var response = await _httpClient.SendAsync(request);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        var content = await response.Content.ReadAsStringAsync();
        return !string.IsNullOrEmpty(content) ? JsonSerializer.Deserialize<T>(content, _jsonSerializerOptions)! : default;
    }

    public async Task<T> PostAsync<T>(string endpoint, object body)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Post,
            _settings.AzureFunctionUri +
            endpoint);
        request.Content = JsonContent.Create(body);
        var response = await _httpClient.SendAsync(request);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
    }

    public async Task<T> PutAsync<T>(string endpoint, object body)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Put,
            _settings.AzureFunctionUri +
            endpoint);
        request.Content = JsonContent.Create(body);
        var response = await _httpClient.SendAsync(request);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), _jsonSerializerOptions)!;
    }

    public async Task DeleteFromRouteAsync(string endpoint, object id)
    {
        var request = new HttpRequestMessage(
            HttpMethod.Delete,
            _settings.AzureFunctionUri +
            endpoint +
            $"/{id}");
        var response = await _httpClient.SendAsync(request);

        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }
    }
}