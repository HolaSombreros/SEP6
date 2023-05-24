namespace MovieManagement.Database.Repositories;

public interface IRatingRepository : IRepository<RatingEntity>
{
    Task<RatingEntity?> GetMovieUserRatingAsync(int movieId, Guid? userId);
    Task<List<RatingEntity>> GetAllMovieRatingsAsync(IList<int> ids);
    Task<(IList<RatingEntity> ratingEntities, int totalPages)> GetMovieRatingsAsync(int? movieId, Guid? userId, int pageNumber);
}