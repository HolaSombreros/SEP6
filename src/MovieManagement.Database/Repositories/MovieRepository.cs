namespace MovieManagement.Database.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<MovieEntity?> _repository;

    public MovieRepository(MovieManagementDbContext context, IRepository<MovieEntity?> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<MovieEntity?> AddMovie(MovieEntity movie)
    {
        return await _repository.AddAsync(movie);
    }

    public async Task<MovieEntity?> GetMovieById(int id)
    {
        return await _context.Movies.FirstOrDefaultAsync(x => x.MovieId == id);
    }
}