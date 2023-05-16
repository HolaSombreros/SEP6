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
    public async Task<RatingEntity?> GetAsync(Guid id) {
        return await _repository.GetAsync(id);
    }
    public async Task<RatingEntity?> UpdateAsync(RatingEntity entity) {
        return await _repository.UpdateAsync(entity);
    }
}