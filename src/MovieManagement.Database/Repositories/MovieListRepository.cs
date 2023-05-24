namespace MovieManagement.Database.Repositories;

public class MovieListRepository : IMovieListRepository {
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<MovieListEntity?> _repository;

    public MovieListRepository(MovieManagementDbContext context, IRepository<MovieListEntity?> repository) {
        _context = context;
        _repository = repository;
    }

    public async Task<List<MovieEntity>> GetMoviesByListAsync(Guid? listId) {
        return  await (from movie in _context.Movies
            join movielistMovie in _context.MovieListMovies on movie.MovieId equals movielistMovie.MovieId
            where movielistMovie.MovieListId == listId
            select new MovieEntity(){MovieId = movie.MovieId, Title = movie.Title, PosterUrl = movie.PosterUrl, ReleaseDate = movie.ReleaseDate}).ToListAsync();
    }
    
    public async Task<IList<MovieListEntity>> GetMovieListsByUserAsync(Guid userId) {
        var list = await _context.MovieLists.Select(m => m).Where(m => m.UserId.Equals(userId)).ToListAsync();
        return list;
    }

    public async Task<MovieListEntity?> GetAsync(Guid id) {
        return await _repository.GetAsync(id);
    }

    public async Task<MovieListEntity?> AddAsync(MovieListEntity entity) {
        return await _repository.AddAsync(entity);
    }
    
    public async Task DeleteAsync(Guid id) {
        await _repository.DeleteAsync(id);
    }
}