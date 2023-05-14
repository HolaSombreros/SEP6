namespace MovieManagement.Components;

public partial class MovieCredits : ComponentBase
{
    [Parameter] 
    public MovieCreditsViewModel Credits { get; set; } = default!;
    
    async Task ScrollRight(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollRight", id, 200);
    }

    async Task ScrollLeft(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollLeft", id, 200);
    }
}