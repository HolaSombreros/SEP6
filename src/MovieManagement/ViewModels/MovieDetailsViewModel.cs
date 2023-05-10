namespace MovieManagement.ViewModels;

public class MovieDetailsViewModel
{
    public int Id { get; }
    public string Title { get; }
    public int Revenue { get; }
    public DateTime ReleaseDate { get; }
    public int Budget { get; }
    public string Description { get; }
    public bool IsAdult { get; }
    public string ImageUrl { get; }
    public IReadOnlyList<Genre> Genres { get; }
    public IReadOnlyList<MovieDetailsCrewViewModel> Crew { get; }
    public IReadOnlyList<MovieDetailsCastViewModel> Cast { get; }


    public MovieDetailsViewModel(Movie movie, IList<Cast> cast, IList<Crew> crew)
    {
        Id = movie.Id;
        Title = movie.Title;
        Revenue = movie.Revenue;
        ReleaseDate = movie.ReleaseDate;
        Budget = movie.Budget;
        Description = movie.Description;
        IsAdult = movie.IsAdult;
        ImageUrl = movie.ImageUrl;
        Genres = movie.Genres.ToList();
        Cast = cast.Select(person => new MovieDetailsCastViewModel(person)).ToList();
        Crew = crew.Select(person => new MovieDetailsCrewViewModel(person)).ToList();
    }
}