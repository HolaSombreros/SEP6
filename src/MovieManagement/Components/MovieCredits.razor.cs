namespace MovieManagement.Components;

public partial class MovieCredits : ComponentBase
{
    [Parameter] public MovieCreditsViewModel Credits { get; set; } = default!;

    private async Task ScrollRight(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollRight", id, 200);
    }

    private async Task ScrollLeft(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollLeft", id, 200);
    }

    private void GoToPersonDetails(long id)
    {
        NavigationManager.NavigateTo($"/people/{id}");
    }
}