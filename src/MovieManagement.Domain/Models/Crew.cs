namespace MovieManagement.Domain.Models;

public class Crew
{
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; }= default!;
    public Role Role { get; set; } = default!;
    public DateTime BirthDate { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}