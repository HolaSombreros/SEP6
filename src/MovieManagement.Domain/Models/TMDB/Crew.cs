namespace MovieManagement.Domain.Models.TMDB;

public class Crew
{
    public int Id { get; set; }
    public string Department { get; set; } = default!;
    public string Name { get; set; } = default!;
    public Role Role { get; set; } = default!;
    public double Popularity { get; set; }
    public string OriginalName { get; set; } = default!;
    public int Gender { get; set; }
    public string ImageUrl { get; set; } = default!;
}