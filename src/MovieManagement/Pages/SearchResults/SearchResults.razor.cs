namespace MovieManagement.Pages.SearchResults;

public partial class SearchResults : ComponentBase
{
    [Parameter]
    public string SearchInput { get; set; } = default!;
    private SearchResultsViewModel? searchResults;

    private const int serviceMaxCallCount = 5;

    protected override async Task OnInitializedAsync()
    {
        var page = 1;
        var data = await SearchService.SearchAllAsync(SearchInput, page);
        searchResults = new(data);

        if (data.TotalPages >= serviceMaxCallCount)
        {
            while (page++ < serviceMaxCallCount)
            {
                data = await SearchService.SearchAllAsync(SearchInput, page);

                foreach (var movie in data.MovieResults)
                {
                    searchResults.Movies.Add(new SearchMovieViewModel(movie));
                }

                foreach (var person in data.PersonResults)
                {
                    searchResults.People.Add(new SearchPersonViewModel(person));
                }
            }
        }
    }
}
