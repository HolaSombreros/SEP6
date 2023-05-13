namespace MovieManagement.TMDB.Api.Services;

public interface IPersonService
{
    public Task<Credits> GetPersonCredits(int id);
}