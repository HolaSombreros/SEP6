namespace MovieManagement.TMDB.Api.Services;

public interface ISearchService
{
    public Task<SearchAll> SearchAllAsync(string query, int page);
}