namespace MovieManagement.Database.Repositories;

public interface IRatingRepository
{
    Task<RatingEntity?> GetMovieUserRatingAsync(int movieId, Guid userId);
    Task<List<RatingEntity>> GetAllMovieRatingsAsync(IList<int> ids);
    Task<RatingEntity?> UpdateAsync(RatingEntity entity, Guid id);
    Task DeleteAsync(Guid id);
    Task<(IList<RatingEntity> ratingEntities, int totalPages)> GetMovieRatingsAsync(int? movieId, Guid? userId, int pageNumber);
    Task<RatingEntity?> AddAsync(RatingEntity entity);
    Task<RatingEntity?> GetAsync(Guid id);
}