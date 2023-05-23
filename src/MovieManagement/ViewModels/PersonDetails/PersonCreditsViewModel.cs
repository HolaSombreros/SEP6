namespace MovieManagement.ViewModels.PersonDetails; 

public class PersonCreditsViewModel {
    public IReadOnlyList<PersonCastViewModel> Cast { get; }
    public IReadOnlyList<PersonCrewViewModel> Crew { get; }

    public PersonCreditsViewModel(Credits credits)
    {
        Cast = credits.Cast.Select(person => new PersonCastViewModel(person)).ToList();
        Crew = credits.Crew.Select(person => new PersonCrewViewModel(person)).ToList();
    }
}