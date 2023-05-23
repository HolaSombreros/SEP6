namespace MovieManagement.Components.Reviews;

public partial class DeleteReviewModal : ComponentBase
{
    [Parameter]
    public Guid ReviewId { get; set; }

    [CascadingParameter]
    public BlazoredModalInstance Modal { get; set; } = default!;

    private DeleteReviewViewModel viewModel = null!;

    protected override void OnInitialized()
    {
        viewModel = new(RatingService);
    }

    private async Task DeleteReviewAsync()
    {
        if (await viewModel.DeleteReviewAsync(ReviewId))
        {
            await Modal.CloseAsync(ModalResult.Ok());
        }
    }
}
