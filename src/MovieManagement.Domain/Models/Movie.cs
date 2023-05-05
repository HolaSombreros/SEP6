namespace MovieManagement.Domain.Models;

public class Movie
{
    public int? Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public int? Revenue { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public int? Budget { get; set; }
    public string? Description { get; set; } = string.Empty;
    public bool? IsAdult { get; set; }
    public string? ImageUrl { get; set; } = string.Empty;
}