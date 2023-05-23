namespace MovieManagement.Components.MovieLists;

public partial class DeleteMovieList : ComponentBase
{
    [Parameter] 
    public Guid ListId { get; set; }
    
    [CascadingParameter]
    public BlazoredModalInstance Modal { get; set; } = default!;

    private async Task DeleteListAsync()
    {
        await MovieListService.DeleteCustomListAsync(ListId);
        await Modal.CloseAsync(ModalResult.Ok());
    }
}