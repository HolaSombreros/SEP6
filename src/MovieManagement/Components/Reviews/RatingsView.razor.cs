namespace MovieManagement.Components.Reviews;

public partial class RatingsView : ComponentBase
{
    [Parameter]
    public int Count { get; set; } = 10;

    [Parameter]
    public int Rating { get; set; }
}
