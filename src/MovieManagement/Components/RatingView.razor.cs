namespace MovieManagement.Components;

public partial class RatingView : ComponentBase
{
    [Parameter]
    public int MovieId { get; set; }

    private RatingViewModel ratingViewModel = new();

    private void SetRating(int rating)
    {
        ratingViewModel.StarRating = rating;
    }

    private async Task RateMovie()
    {
        var userId = (await AuthenticationStateProvider.GetAuthenticationStateAsync()).User.FindFirstValue("Id");
        // TODO - Call service that maps VM to DTO. Also prevent rating the same movie twice.
        ratingViewModel = new();
    }

    private string IsActive(int rating)
    {
        return rating <= ratingViewModel.StarRating ? "active" : "";
    }
}