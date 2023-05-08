namespace MovieManagement.Domain.Models;

public class MovieCast
{
    public int Id { get; set; } = default!;
    public int Gender { get; set; } = default!;
    public string Name { get; set; } = default!;
    public double Popularity { get; set; } = default!;
    public string Character { get; set; } = default!;
    public int Order { get; set; } = default!;
    public string OriginalName { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}