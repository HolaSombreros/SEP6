namespace MovieManagement.ViewModels.MovieDetails;

public class MovieCreditsViewModel
{
    public IReadOnlyList<MovieDetailsCastViewModel> Cast { get; }
    public IReadOnlyList<MovieDetailsCrewViewModel> Crew { get; }

    public MovieCreditsViewModel(Credits credits)
    {
        Cast = credits.Cast.Select(person => new MovieDetailsCastViewModel(person)).ToList();
        Crew = credits.Crew.Select(person => new MovieDetailsCrewViewModel(person)).ToList();
    }
}