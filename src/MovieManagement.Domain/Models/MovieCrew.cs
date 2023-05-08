namespace MovieManagement.Domain.Models;

public class MovieCrew
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; }= default!;
    public Role? Role { get; set; }
    public DateTime? BirthDate { get; set; }
    public string ImageUrl { get; set; } = default!;
}