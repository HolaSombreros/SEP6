namespace MovieManagement.ViewModels.PersonDetails; 

public class PersonCreditsViewModel {
    public IReadOnlyList<PersonCastViewModel> Cast { get; private set; }
    public IReadOnlyList<PersonCrewViewModel> Crew { get; private set; }

    public PersonCreditsViewModel(Credits credits)
    {
        Cast = credits.Cast.Select(person => new PersonCastViewModel(person)).ToList();
        Crew = credits.Crew.Select(person => new PersonCrewViewModel(person)).ToList();
        SortMoviesByPopularity();
    }

    public void SortMoviesByPopularity()
    {
        Cast = Cast.OrderByDescending(m => m.Popularity).ToList();
        Crew = Crew.OrderByDescending(m => m.Popularity).ToList();
    }

    public void SortMoviesByTitle()
    {
        Cast = Cast.OrderBy(m => m.Title).ToList();
        Crew = Crew.OrderBy(m => m.Title).ToList();
    }
}