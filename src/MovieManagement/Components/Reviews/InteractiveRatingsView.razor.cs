namespace MovieManagement.Components.Reviews;

public partial class InteractiveRatingsView : ComponentBase
{
    [Parameter]
    public int? Count { get; set; } = 10;

    [Parameter]
    public int Rating { get; set; }

    [Parameter]
    public EventCallback<int> RatingChangedCallback { get; set; }

    private async Task SetRating(int rating)
    {
        Rating = rating;
        await RatingChangedCallback.InvokeAsync(rating);
    }
}
