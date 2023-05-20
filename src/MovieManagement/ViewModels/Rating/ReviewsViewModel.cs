namespace MovieManagement.ViewModels.Rating;

public class ReviewsViewModel
{
    private readonly IRatingService ratingService;
    private readonly int movieId;
    private readonly Guid? userGuid;

    public List<ReviewModel>? Reviews { get; private set; }

    public ReviewsViewModel(IRatingService ratingService, int movieId, Guid? userGuid)
    {
        this.ratingService = ratingService;
        this.movieId = movieId;
        this.userGuid = userGuid;
    }

    public async Task GetMovieReviewsAsync()
    {
        Reviews = await ratingService.GetMovieReviewsAsync(movieId, userGuid);
    }
}
