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
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string PosterUrl { get; set; } = default!;
    public DateTime ReleaseDate { get; set; } = default!;
    public double VoteAverage { get; set; } 
    public int VoteCount { get; set; }
}