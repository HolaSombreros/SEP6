namespace MovieManagement.Services;

public interface IAzureService
{ 
    Task<T?> GetAsync<T>(string endpoint, object body, int? page = null);
    Task<T> GetFromRouteAsync<T>(string endpoint, object id);
    Task<T> PostAsync<T>(string endpoint, object body);
    Task<T> PutAsync<T>(string endpoint, object body);
    Task DeleteFromRouteAsync(string endpoint, object id);
}