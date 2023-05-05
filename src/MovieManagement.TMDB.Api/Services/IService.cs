namespace MovieManagement.TMDB.Api.Services;

public interface IService
{
    public Task<T> GetAsync<T>(string endpoint);

}