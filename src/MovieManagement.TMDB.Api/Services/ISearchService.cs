namespace MovieManagement.TMDB.Api.Services;

public interface ISearchService
{
    public Task<SearchAll> SearchAll(string query, int page);
}