namespace MovieManagement.Components.Reviews;

public partial class ReviewView : ComponentBase
{
    [Parameter]
    public ReviewModel Review { get; set; } = default!;

    [Parameter]
    public EventCallback<Guid> RemoveCallback { get; set; } = default!;

    [CascadingParameter]
    public IModalService Modal { get; set; } = default!;

    [Parameter]
    public bool CanDeleteReview { get; set; }

    private async Task ShowDeleteModal()
    {
        var modalParameters = new ModalParameters()
            .Add(nameof(DeleteReviewModal.ReviewId), Review.Id);

        var modal = Modal.Show<DeleteReviewModal>("Delete Review", modalParameters);
        var result = await modal.Result;

        if (result.Confirmed)
        {
            await RemoveCallback.InvokeAsync(Review.Id);
        }

        modal.Close();
    }
}
