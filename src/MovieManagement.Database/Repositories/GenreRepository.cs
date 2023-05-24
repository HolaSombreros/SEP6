namespace MovieManagement.Database.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<GenreEntity?> _repository;


    public GenreRepository(MovieManagementDbContext context, IRepository<GenreEntity?> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<GenreEntity?> GetGenreByIdAsync(int id)
    {
        return await _context.Genres.AsNoTracking().SingleOrDefaultAsync(x => x.GenreId == id);
    }

    public async Task<GenreEntity?> AddGenreAsync(GenreEntity? entity)
    {
        return await _repository.AddAsync(entity);
    }
}