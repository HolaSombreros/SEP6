namespace MovieManagement.ViewModels.Search;

public class SearchResultsViewModel
{
    public int Results => Movies.Count + People.Count;
    public List<SearchMovieViewModel> Movies { get; set; }
    public List<SearchPersonViewModel> People { get; set; }

    public SearchResultsViewModel(SearchAll data)
    {
        Movies = new List<SearchMovieViewModel>();
        People = new List<SearchPersonViewModel>();

        foreach (var movie in data.MovieResults)
        {
            Movies.Add(new SearchMovieViewModel(movie));
        }

        foreach (var person in data.PersonResults)
        {
            People.Add(new SearchPersonViewModel(person));
        }
    }
}
