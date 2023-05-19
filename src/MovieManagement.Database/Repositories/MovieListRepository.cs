namespace MovieManagement.Database.Repositories; 

public class MovieListRepository : IMovieListRepository{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<MovieListEntity?> _repository;

    public MovieListRepository(MovieManagementDbContext context, IRepository<MovieListEntity?> repository) {
        _context = context;
        _repository = repository;
    }

    public async Task<MovieListEntity?> GetAsync(Guid id) {
        throw new NotImplementedException();
    }

    public async Task<MovieListEntity?> AddAsync(MovieListEntity entity) {
        return await _repository.AddAsync(entity);
    }

    public async Task<MovieListEntity?> UpdateAsync(MovieListEntity entity, Guid id) {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(Guid id) {
        throw new NotImplementedException();
    }
}