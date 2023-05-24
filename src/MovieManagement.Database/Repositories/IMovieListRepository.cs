namespace MovieManagement.Database.Repositories; 

public interface IMovieListRepository {
    Task<IList<MovieListEntity>> GetMovieListsByUserAsync(Guid userId);
    Task<List<MovieEntity>> GetMoviesByListAsync(Guid? listId);
    Task<MovieListEntity?> GetAsync(Guid id);
    Task<MovieListEntity?> AddAsync(MovieListEntity entity);
    Task DeleteAsync(Guid id);
}