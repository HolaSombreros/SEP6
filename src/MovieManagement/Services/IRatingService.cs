namespace MovieManagement.Services;

public interface IRatingService
{
    Task<RatingViewModel> RateMovieAsync(RatingViewModel ratingViewModel, MovieDetailsViewModel movieDetailsViewModel, Guid userId);
    Task<List<ReviewModel>> GetMovieReviewsAsync(int movieId, Guid? userId);
}
