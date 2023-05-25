namespace MovieManagement.Services;

public interface IRatingService
{
    Task CreateMovieReviewAsync(CreateReviewModel reviewModel, MovieModel movieModel, Guid userGuid);
    Task<PaginatedReviewsModel> GetMovieReviewsAsync(int movieId, Guid? userGuid, int page);
    Task<ReviewModel?> GetUserMovieRating(int movieId, Guid userGuid);
    Task DeleteMovieReviewAsync(Guid reviewId);
    Task<IList<MovieRatingModel>> GetMovieRatingsAsync(int[] movieIds);
    event Action<ReviewModel>? OnReviewCreated;
}
