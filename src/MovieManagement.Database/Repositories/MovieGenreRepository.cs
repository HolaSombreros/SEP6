namespace MovieManagement.Database.Repositories;

public class MovieGenreRepository : IMovieGenreRepository
{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<MovieGenreEntity?> _repository;

    public MovieGenreRepository(MovieManagementDbContext context, IRepository<MovieGenreEntity?> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<MovieGenreEntity?> AddMovieGenreAsync(MovieGenreEntity movieGenre)
    {
        return await _repository.AddAsync(movieGenre);
    }

    public async Task<MovieGenreEntity?> GetMovieGenreAsync(int movieId, int genreId)
    {
        return await _context.MovieGenres.AsNoTracking().SingleOrDefaultAsync(m =>
            m.MovieId.Equals(movieId) &&
            m.GenreId.Equals(genreId));
    }

    public async Task<IList<MovieGenreEntity?>> GetMoviesByGenre(int genreId)
    {
        return (await _context.MovieGenres.AsNoTracking().Where(m => m.GenreId == genreId).ToListAsync())!;
    }
}