namespace MovieManagement.Functions.Services;

public interface IGenreService
{
    Task<GenreDto> GetGenreByIdAsync(int id);
    Task<IList<GenreDto>> AddGenreAsync(IList<GenreDto> genres);
}