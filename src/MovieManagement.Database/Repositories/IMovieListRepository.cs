namespace MovieManagement.Database.Repositories; 

public interface IMovieListRepository {
    Task<IList<MovieListEntity>> GetMovieListsByUser(Guid userId);
    Task<List<MovieEntity>> GetMoviesByList(Guid? listId);
    Task<MovieListEntity?> GetAsync(Guid id);
    Task<MovieListEntity?> AddAsync(MovieListEntity entity);
    Task DeleteAsync(Guid id);
}