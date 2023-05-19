namespace MovieManagement.Components;

public partial class RatingView : ComponentBase
{
    [Parameter]
    public MovieDetailsViewModel MovieDetails { get; set; } = default!;

    private RatingViewModel ratingViewModel = new();
    private Guid userId = default!;
    private string resultMessage = string.Empty;
    private string resultCssClass = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        var tempUserId = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        if (tempUserId != null)
        {
            userId = Guid.Parse(tempUserId);
        }
    }

    private void SetRating(int rating)
    {
        ratingViewModel.StarRating = rating;
    }

    private async Task RateMovie()
    {
        resultMessage = "";
        try
        {
            var rating = await RatingService.RateMovie(ratingViewModel, MovieDetails, userId);
            ratingViewModel = new();
            resultMessage = "Review successfully added!";
            resultCssClass = "success-message";
        }
        catch (Exception ex)
        {
            resultMessage = ex.Message;
            resultCssClass = "error-message";
        }
    }

    private string IsActive(int rating)
    {
        return rating <= ratingViewModel.StarRating ? "active" : "";
    }
}