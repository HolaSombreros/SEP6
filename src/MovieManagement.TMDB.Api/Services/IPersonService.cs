namespace MovieManagement.TMDB.Api.Services;

public interface IPersonService
{
    public Task<Credits> GetPersonCreditsAsync(int id);
    public Task<Person> GetPersonDetailsAsync(int id);
}