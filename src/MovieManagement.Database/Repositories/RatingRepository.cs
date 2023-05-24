namespace MovieManagement.Database.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<RatingEntity?> _repository;
    private const int PageSize = 20;

    public RatingRepository(MovieManagementDbContext context, IRepository<RatingEntity?> repository)
    {
        _context = context;
        _repository = repository;
    }

    public async Task<RatingEntity?> GetMovieUserRatingAsync(int movieId, Guid? userId)
    {
        return await _context.Ratings.FirstOrDefaultAsync(r =>
            r.UserEntity.UserId.Equals(userId) && r.MovieEntity.MovieId.Equals(movieId));
    }

    public async Task<List<RatingEntity>> GetAllMovieRatingsAsync(IList<int> ids)
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
    public async Task<(IList<RatingEntity> ratingEntities, int totalPages)> GetMovieRatingsAsync(int? movieId, Guid? userId, int pageNumber)
    {
        var list = await _context.Ratings
            .Where(r => movieId.Equals(r.MovieId))
            .ToListAsync();

        var totalResults = await TotalResultsByMovie(movieId);
        
         var orderedList = list
             .OrderBy(r => r.UserId == userId ? 0 : 1)
             .Skip((pageNumber - 1) * PageSize)
             .Take(PageSize).ToList();
         
         var totalPages = (int)Math.Ceiling((double)totalResults / PageSize);
         return (orderedList, totalPages);
    }

    private async Task<int> TotalResultsByMovie(int? movieId)
    {
        return (await _context.Ratings
            .Where(r => movieId.Equals(r.MovieId))
            .ToListAsync()).Count;
    }

    public async Task<RatingEntity?> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<RatingEntity?> UpdateAsync(RatingEntity entity, Guid id)
    {
        var existingRating = await GetMovieUserRatingAsync(entity.MovieId, entity.UserId);
        
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