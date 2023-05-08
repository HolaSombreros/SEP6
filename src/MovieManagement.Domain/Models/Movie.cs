namespace MovieManagement.Domain.Models;

public class Movie
{
    public int Id { get; set; } = default!;
    public string Title { get; set; } = default!;
    public int Revenue { get; set; } = default!;
    public DateTime? ReleaseDate { get; set; }
    public int Budget { get; set; } = default!;
    public string Description { get; set; } = default!;
    public bool IsAdult { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}