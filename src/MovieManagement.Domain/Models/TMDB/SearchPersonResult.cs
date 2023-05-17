namespace MovieManagement.Domain.Models.TMDB;

public class SearchPersonResult
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? ProfilePath { get; set; }
    public string? KnownFor { get; set; }
}