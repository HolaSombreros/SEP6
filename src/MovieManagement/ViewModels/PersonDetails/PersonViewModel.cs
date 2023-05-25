namespace MovieManagement.ViewModels.PersonDetails;

public class PersonViewModel
{
    public int Id { get; }
    public DateTime Birthday { get; }
    public string Name { get; }
    public string Biography { get; }
    public DateTime DeathDay { get; }
    public string PlaceOfBirth { get; }
    public string ImageUrl { get; }
    public PersonCreditsViewModel Credits { get; }

    public PersonViewModel(Person person, Credits credits)
    {
        Id = person.Id;
        Birthday = person.Birthday ?? new DateTime(1,1,1);
        Name = person.Name;
        Biography = person.Biography;
        DeathDay = person.DeathDay ?? new DateTime(1,1,1);
        PlaceOfBirth = person.PlaceOfBirth;
        ImageUrl = !string.IsNullOrEmpty(person.ImageUrl) ? person.ImageUrl : "Images/CreditMemberMissingPicture.png";
        Credits = new PersonCreditsViewModel(credits);
    }
}