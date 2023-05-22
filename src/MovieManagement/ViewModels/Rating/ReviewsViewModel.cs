namespace MovieManagement.ViewModels.Rating;

public class ReviewsViewModel
{
    private readonly IRatingService ratingService;
    private readonly int movieId;
    private readonly Guid? userGuid;

    public PaginatedReviewsModel? PaginatedReviews { get; set; }

    public ReviewsViewModel(IRatingService ratingService, int movieId, Guid? userGuid)
    {
        this.ratingService = ratingService;
        this.movieId = movieId;
        this.userGuid = userGuid;
    }

    public async Task GetMovieReviewsAsync(int page)
    {
        var reviews = await ratingService.GetMovieReviewsAsync(movieId, userGuid, page);

        if (PaginatedReviews == null)
        {
            PaginatedReviews = reviews;
        }
        else
        {
            PaginatedReviews.Page = reviews.Page;
            PaginatedReviews.Reviews.AddRange(reviews.Reviews);
        }
    }
}
