namespace MovieManagement.Database.Repositories;

public interface IGenreRepository
{
    Task<GenreEntity?> GetGenreByIdAsync(int id);
    Task<GenreEntity?> AddGenreAsync(GenreEntity? entity);
}