namespace MovieManagement.ViewModels.PersonDetails;

public class PersonCrewViewModel {
    public int Id { get; }
    public string Department { get; }
    public string Name { get; }
    public string OriginalName { get; }
    public int Gender { get; }
    public string ImageUrl { get; }
    public string Title { get; }
    public string Description { get; }
    public string PosterUrl { get; }
    public string ReleaseDate { get; } 
    public double VoteAverage { get; }
    public int VoteCount { get; }

    public PersonCrewViewModel(Crew crew) {
        Id = crew.Id;
        Gender = crew.Gender;
        Name = crew.Name;
        Department = crew.Department;
        OriginalName = crew.OriginalName;
        ImageUrl = !string.IsNullOrEmpty(crew.ImageUrl) ? crew.ImageUrl : "Images/CreditMemberMissingPicture.png";
        Title = crew.Title;
        Description = crew.Description;
        PosterUrl = crew.PosterUrl;
        ReleaseDate = crew.ReleaseDate.ToString("dd/MM/yyyy");
        VoteAverage = crew.VoteAverage;
        VoteCount = crew.VoteCount;
    }
}