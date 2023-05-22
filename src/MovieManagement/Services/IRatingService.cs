namespace MovieManagement.Services;

public interface IRatingService
{
    Task CreateMovieReview(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid);
    Task<PaginatedReviewsModel> GetMovieReviewsAsync(int movieId, Guid? userId, int page);
}
