namespace MovieManagement.Database.Repositories;

public class MovieListMovieRepository : IMovieListMovieRepository
{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<MovieListMovieEntity?> _repository;

    public MovieListMovieRepository(MovieManagementDbContext context, IRepository<MovieListMovieEntity?> repository)
    {
        _context = context;
        _repository = repository;
    }
    
    public async Task<MovieListMovieEntity?> AddMovieToMovieListAsync(MovieListMovieEntity movieListMovieEntity)
    {
        return await _repository.AddAsync(movieListMovieEntity);

    }

    public async Task<MovieListMovieEntity?> GetMovieFromMovieListAsync(MovieListMovieEntity movieListMovieEntity)
    {
        return await _context.MovieListMovies.AsNoTracking().SingleOrDefaultAsync(m =>
            m.MovieListId.Equals(movieListMovieEntity.MovieListId) &&
            m.MovieId.Equals(movieListMovieEntity.MovieId));
    }

    public async Task DeleteMovieFromMovieListAsync(MovieListMovieEntity movieListMovieEntity)
    {
        _context.MovieListMovies.Remove(movieListMovieEntity);
       await _context.SaveChangesAsync();
    }
}