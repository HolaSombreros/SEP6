namespace MovieManagement.Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public int Revenue { get; set; }
    public DateTime ReleaseDate { get; set; } = default!;
    public int Budget { get; set; }
    public string Description { get; set; } = default!;
    public bool IsAdult { get; set; }
    public string ImageUrl { get; set; } = default!;
}