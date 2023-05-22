namespace MovieManagement.Components.MovieLists;

public partial class DeleteMovieList : ComponentBase
{
    [Parameter] 
    public Guid ListId { get; set; }
    private string _successMessage = string.Empty;

    private async Task DeleteListAsync()
    {
        await MovieListService.DeleteCustomListAsync(ListId);
        _successMessage = "The list has been successfully removed";
    }
}