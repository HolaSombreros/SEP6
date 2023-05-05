namespace MovieManagement.Domain.Models;

public class MovieCrew
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Role? Role { get; set; }
    public DateTime? BirthDate { get; set; }
}