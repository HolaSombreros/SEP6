using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MovieManagement.ViewModels.MovieDetails;

namespace MovieManagement.Pages.MovieDetails;

public partial class MovieCredits : ComponentBase
{
    [Parameter] public MovieCreditsViewModel Credits { get; set; } = default!;
    
    async Task ScrollRight(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollRight", id, 200);
    }

    async Task ScrollLeft(string id)
    {
        await JsRuntime.InvokeVoidAsync("ScrollLeft", id, 200);
    }
}