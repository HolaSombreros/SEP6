namespace MovieManagement.Components.Reviews;

public partial class InteractiveRatingView : ComponentBase
{
    [Parameter]
    public int RatingNumber { get; set; }

    [Parameter]
    public bool IsActive { get; set; }

    [Parameter]
    public EventCallback<int> RatingChangedCallback { get; set; }

    private async Task OnClick()
    {
        await RatingChangedCallback.InvokeAsync(RatingNumber);
    }

    private string CssClass => IsActive ? "active" : "";
}
