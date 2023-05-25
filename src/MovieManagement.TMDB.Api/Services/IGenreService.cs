namespace MovieManagement.TMDB.Api.Services;

public interface IGenreService
{
    public Task<GenreList>? GetAllGenresAsync();
}