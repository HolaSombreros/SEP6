namespace MovieManagement.Services;

public interface IRatingService
{
    Task CreateMovieReviewAsync(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid);
    Task<PaginatedReviewsModel> GetMovieReviewsAsync(int movieId, Guid? userId, int page);
    Task DeleteMovieReviewAsync(Guid reviewId);
}
