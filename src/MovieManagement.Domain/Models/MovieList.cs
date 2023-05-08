namespace MovieManagement.Domain.Models;

public class MovieList
{
    public int TotalPages { get; set; } = default!;
    public int TotalResults { get; set; } = default!;
    public DatePeriod? Dates { get; set; }
    public List<Movie>? Movies { get; set; }
    public int Page { get; set; } = default!;
    public string ListType { get; set; } = default!;
}