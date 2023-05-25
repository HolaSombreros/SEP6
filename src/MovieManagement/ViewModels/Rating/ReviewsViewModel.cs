namespace MovieManagement.ViewModels.Rating;

public class ReviewsViewModel : IDisposable
{
    private readonly IRatingService ratingService;
    private readonly int movieId;
    private readonly Guid? userGuid;

    public PaginatedReviewsModel? PaginatedReviews { get; set; }
    public event Action? OnReviewCreated;

    public ReviewsViewModel(IRatingService ratingService, int movieId, Guid? userGuid)
    {
        this.ratingService = ratingService;
        this.movieId = movieId;
        this.userGuid = userGuid;

        ratingService.OnReviewCreated += ReviewCreated;
    }

    public Task<ReviewModel?> GetLoggedInUserReviewAsync()
    {
        return ratingService.GetUserMovieRatingAsync(movieId, (Guid)userGuid!);
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

    public void RemoveReview(Guid reviewId)
    {
        var review = PaginatedReviews!.Reviews.First(r => r.Id == reviewId);
        PaginatedReviews.Reviews.Remove(review);
    }

    private void ReviewCreated(ReviewModel review)
    {
        var existingUserReview = PaginatedReviews!.Reviews.FirstOrDefault(r => r.Id == review.Id);

        if (existingUserReview != null)
        {
            PaginatedReviews.Reviews.Remove(existingUserReview);
        }

        PaginatedReviews.Reviews.Insert(0, review);
        OnReviewCreated?.Invoke();
    }

    public void Dispose()
    {
        ratingService.OnReviewCreated -= ReviewCreated;
    }
}
