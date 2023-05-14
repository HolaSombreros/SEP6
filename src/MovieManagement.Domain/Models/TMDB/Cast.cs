namespace MovieManagement.Domain.Models.TMDB;

public class Cast
{
    public int Id { get; set; }
    public int Gender { get; set; }
    public string Name { get; set; } = default!;
    public double Popularity { get; set; }
    public string Character { get; set; } = default!;
    public int Order { get; set; }
    public string OriginalName { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
}