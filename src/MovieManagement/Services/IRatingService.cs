namespace MovieManagement.Services;

public interface IRatingService
{
    Task CreateMovieReview(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid);
    Task<IEnumerable<ReviewModel>> GetMovieReviewsAsync(int movieId, Guid? userId, int page);
}
