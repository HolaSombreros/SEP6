namespace MovieManagement.Domain.Models;

public class MovieList
{
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
    public DatePeriod Dates { get; set; } = default!;
    public List<Movie> Movies { get; set; } = default!;
    public int Page { get; set; }
    public string ListType { get; set; } = default!;
}