namespace MovieManagement.Components.Reviews;

public partial class ReviewsView : ComponentBase
{
    [Parameter]
    public int MovieId { get; set; }

    private ReviewsViewModel viewModel = default!;

    protected override async Task OnInitializedAsync()
    {
        var userIdAsString = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        viewModel = Guid.TryParse(userIdAsString, out var userIdAsGuid)
            ? (new(RatingService, MovieId, userIdAsGuid))
            : (new(RatingService, MovieId, null));

        var startPage = 1;
        await GetMovieReviews(startPage);
    }

    private Task FetchDataAsync()
    {
        var nextPage = viewModel.PaginatedReviews!.Page + 1;
        return nextPage <= viewModel.PaginatedReviews.TotalPages ? GetMovieReviews(nextPage) : Task.CompletedTask;
    }

    private Task GetMovieReviews(int page)
    {
        return viewModel.GetMovieReviewsAsync(page);
    }
}
