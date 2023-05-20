namespace MovieManagement.Services;

public interface IRatingService
{
    public Task<RatingViewModel> RateMovieAsync(RatingViewModel ratingViewModel, MovieDetailsViewModel movieDetailsViewModel, Guid userId);
}
