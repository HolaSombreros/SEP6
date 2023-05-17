namespace MovieManagement.Services;

public interface IAzureService
{ 
    Task<T> PostAsync<T>(string endpoint, object body);
    Task<T> PutAsync<T>(string endpoint, object body);
    Task DeleteAsync(string endpoint, object body);
}