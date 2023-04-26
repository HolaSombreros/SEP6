namespace MovieManagement.Domain.Models;

public class Movie
{
    public string Title { get; set; }
    public float Profit { get; set; }
    public int YearOfRelease { get; set; }
    public int Length { get; set; }
    public float Budget { get; set; }
}