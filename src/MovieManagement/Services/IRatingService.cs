namespace MovieManagement.Services;

public interface IRatingService
{
    public Task<RatingViewModel> RateMovie(RatingViewModel ratingViewModel, MovieDetailsViewModel movieViewModel, Guid userId);
}
