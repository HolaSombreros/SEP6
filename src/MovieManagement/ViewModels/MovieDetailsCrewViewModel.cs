namespace MovieManagement.ViewModels;

public class MovieDetailsCrewViewModel
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Role { get; }
    public string ImageUrl { get; }

    public MovieDetailsCrewViewModel(Crew crew)
    {
        FirstName = crew.Name;
        Role = crew.Job;
        ImageUrl = crew.ImageUrl;
    }
}