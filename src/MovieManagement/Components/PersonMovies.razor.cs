namespace MovieManagement.Components;

public partial class PersonMovies : ComponentBase
{
    [Parameter] 
    public PersonCreditsViewModel Credits { get; set; } = default!;

    private void GoToMovieDetails(long id)
    {
        NavigationManager.NavigateTo($"/Movies/{id}");
    }
}