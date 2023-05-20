namespace MovieManagement.Components.Reviews;

public partial class ReviewView : ComponentBase
{
    [Parameter]
    public ReviewModel Review { get; set; } = default!;
}
