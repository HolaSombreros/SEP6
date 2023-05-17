namespace MovieManagement.ViewModels.PersonDetails; 

public class PersonViewModel {
    public int Id { get; }
    public string Birthday { get; }
    public string Name { get; }
    public string Biography { get; }
    public string DeathDay { get;  }
    public string PlaceOfBirth { get; }
    public string ImageUrl { get; }
    public PersonCreditsViewModel Credits { get; }

    public PersonViewModel(Person person, Credits credits) {
        Id = person.Id;
        Birthday = person.Birthday.ToString("dd/MM/yyyy");
        Name = person.Name;
        Biography = person.Biography;
        DeathDay = person.DeathDay.HasValue ? person.DeathDay.Value.ToString("dd/MM/yyyy") : string.Empty;
        PlaceOfBirth = person.PlaceOfBirth;
        ImageUrl = !string.IsNullOrEmpty(person.ImageUrl) ? person.ImageUrl : "Images/CreditMemberMissingPicture.png";
        Credits = new PersonCreditsViewModel(credits);
    }
}