namespace MovieManagement.Domain.Models.TMDB;

public class Crew
{
    public int Id { get; set; }
    public string Department { get; set; } = default!;
    public string Name { get; set; } = default!;
    public Role Role { get; set; }
    public double Popularity { get; set; }
    public string OriginalName { get; set; } = default!;
    public int Gender { get; set; }
    public string ImageUrl { get; set; } = default!;
    public DateTime ReleaseDate { get; set; } = default!;
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string PosterUrl { get; set; } = default!;
    public double VoteAverage { get; set; }
    public int VoteCount { get; set; }
}