namespace MovieManagement.TMDB.Api.Services;

public interface IPersonService
{
    public Task<Credits> GetPersonCredits(int id);
    public Task<Person> GetPersonDetails(int id);
}