namespace MovieManagement.Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Revenue { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int Budget { get; set; }
}