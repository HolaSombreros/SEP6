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
    public string ReleaseDate { get; }
    public string VoteAverage { get; }
    public string VoteCount { get; }

    public PersonCrewViewModel(Crew crew)
    {
        Id = crew.Id;
        Gender = crew.Gender;
        Name = crew.Name;
        Department = crew.Department;
        Title = crew.Title;
        Description = crew.Description;
        PosterUrl = !string.IsNullOrEmpty(crew.PosterUrl) ? crew.PosterUrl : "Images/MovieMissingPicture.png";
        ReleaseDate = !crew.ReleaseDate.Equals(new DateTime(1, 1, 1))
            ? crew.ReleaseDate.ToString("dd/MM/yyyy")
            : string.Empty;
        VoteAverage = Math.Round(crew.VoteAverage, 2).ToString(CultureInfo.CurrentCulture);
        VoteCount = $"{crew.VoteCount:n0}";
    }
}