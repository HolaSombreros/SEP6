namespace MovieManagement.ViewModels.MovieDetails;

public class MovieDetailsCrewViewModel
{
    public int Id { get; }
    public string Name { get; }
    public string Department { get; }
    public string ImageUrl { get; }
    public Role Role { get; set; }

    public MovieDetailsCrewViewModel(Crew crew)
    {
        Id = crew.Id;
        Name = crew.Name;
        Department = crew.Department;
        Role = crew.Role;
        ImageUrl = !string.IsNullOrEmpty(crew.ImageUrl) ? crew.ImageUrl : "Images/CreditMemberMissingPicture.png";
    }
}