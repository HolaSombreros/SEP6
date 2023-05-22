namespace MovieManagement.Components;

public partial class MovieCredits : ComponentBase
{
    [Parameter] 
    public MovieCreditsViewModel Credits { get; set; } = default!;

    private async Task ScrollRightAsync(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollRight", id, 200);
    }

    private async Task ScrollLeftAsync(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollLeft", id, 200);
    }
}