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
    
    public async Task<List<MovieEntity>> GetMoviesByListAsync(Guid? listId) {
        return  await (from movie in _context.Movies
            join movielistMovie in _context.MovieListMovies on movie.MovieId equals movielistMovie.MovieId
            where movielistMovie.MovieListId == listId
            select new MovieEntity(){MovieId = movie.MovieId, Title = movie.Title, PosterUrl = movie.PosterUrl, ReleaseDate = movie.ReleaseDate}).ToListAsync();
    }
}