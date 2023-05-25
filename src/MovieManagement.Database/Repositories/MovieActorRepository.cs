namespace MovieManagement.Database.Repositories; 

public class MovieActorRepository : IMovieActorRepository {
    
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<MovieActorEntity?> _repository;

    public MovieActorRepository(MovieManagementDbContext context, IRepository<MovieActorEntity?> repository) {
        _context = context;
        _repository = repository;
    }

    public async Task<MovieActorEntity?> AddMovieActorAsync(MovieActorEntity movieActorEntity) {
        return await _repository.AddAsync(movieActorEntity);
    }

    public async Task<List<MovieEntity?>> GetMoviesForActor(int actorId) {
        throw new NotImplementedException();
    }

    public async Task<List<MovieActorEntity?>> GetMoviesRolesForActor(int actorId) {
        throw new NotImplementedException();
    }

    public async Task<MovieActorEntity?> GetAsync(int actorId, int movieId) {
        return await _context.MovieActors.FindAsync(actorId, movieId);
    }
}

