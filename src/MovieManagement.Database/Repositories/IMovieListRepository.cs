namespace MovieManagement.Database.Repositories; 

public interface IMovieListRepository : IRepository<MovieListEntity> {
    Task<IList<MovieListEntity>> GetMovieListsByUser(Guid userId);
    Task<List<MovieEntity>> GetMoviesByList(Guid? listId);
}