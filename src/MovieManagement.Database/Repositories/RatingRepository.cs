namespace MovieManagement.Database.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<RatingEntity?> _repository;

    public RatingRepository(MovieManagementDbContext context, IRepository<RatingEntity?> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<RatingEntity?> GetMovieUserRating(int movieId, Guid userId)
    {
        return await _context.Ratings.FirstOrDefaultAsync(r =>
            r.UserEntity.UserId.Equals(userId) && r.MovieEntity.MovieId.Equals(movieId));
    }

    public async Task<List<RatingEntity>> GetAllMovieRatings(IList<int> ids)
    {
        return await _context.Ratings
            .Where(r => ids.Contains(r.MovieId))
            .Select(g => new RatingEntity
            {
                MovieId = g.MovieId,
                Rating = g.Rating
            })
            .ToListAsync();
    }
    public async Task<IList<RatingEntity>> GetMovieRatings(int movieId, Guid userId, int pageNumber, int pageSize)
    {
        var list = await _context.Ratings
            .Where(r => movieId.Equals(r.MovieId))
             .Select(g => new RatingEntity
             {
                 MovieId = g.MovieId,
                 Rating = g.Rating,
                 Review = g.Review,
                 UserId = g.UserId
             }).ToListAsync();
        
         return list
             .OrderBy(r => r.UserId == userId ? 0 : 1)
             .Skip((pageNumber - 1) * pageSize)
             .Take(pageSize).ToList();
    }

    public async Task<RatingEntity?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }
    public async Task<RatingEntity?> UpdateAsync(RatingEntity entity, Guid id)
    {
        var existingRating = await GetMovieUserRating(entity.MovieId, entity.UserId);
        
        if (existingRating is not null)
        {
            existingRating.Rating = entity.Rating;
            existingRating.Review = entity.Review;
        }
        await _context.SaveChangesAsync();
        return entity;
    }
    
    public async Task<RatingEntity?> AddAsync(RatingEntity entity)
    {
        return await _repository.AddAsync(entity);
    }
    
    public async Task DeleteAsync(Guid id) 
    {
        await _repository.DeleteAsync(id);
    }
}