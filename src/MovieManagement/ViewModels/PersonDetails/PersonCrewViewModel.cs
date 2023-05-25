namespace MovieManagement.ViewModels.PersonDetails;

public class PersonCrewViewModel
{
    public int Id { get; }
    public int Gender { get; }
    public string Name { get; }
    public string Department { get; }
    public string Title { get; }
    public string Description { get; }
    public string PosterUrl { get; }
    public DateTime ReleaseDate { get; }
    public double VoteAverage { get; }
    public int VoteCount { get; }
    public double Popularity { get; set; }

    public PersonCrewViewModel(Crew crew)
    {
        Id = crew.Id;
        Gender = crew.Gender;
        Name = crew.Name;
        Department = crew.Department;
        Title = crew.Title;
        Description = crew.Description;
        PosterUrl = !string.IsNullOrEmpty(crew.PosterUrl) ? crew.PosterUrl : "Images/MovieMissingPicture.png";
        ReleaseDate = crew.ReleaseDate;
        VoteAverage = Math.Round(crew.VoteAverage, 2);
        VoteCount = crew.VoteCount;
        Popularity = crew.Popularity;
    }
}