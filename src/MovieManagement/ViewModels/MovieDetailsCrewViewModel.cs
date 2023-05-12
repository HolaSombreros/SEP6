namespace MovieManagement.ViewModels;

public class MovieDetailsCrewViewModel
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Role { get; }
    public string ImageUrl { get; }

    public MovieDetailsCrewViewModel(Crew crew)
    {
        Role = Enum.GetName(typeof(Role), crew.Role) ?? default!;
        ImageUrl = crew.ImageUrl;
    }
}