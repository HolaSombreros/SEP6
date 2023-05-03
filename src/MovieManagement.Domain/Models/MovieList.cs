namespace MovieManagement.Domain.Models;

public class MovieList
{
    public int TotalPages { get; set; }
    public int TotalResults { get; set; }
    public DatePeriod Dates { get; set; }
    public List<Movie> Movies { get; set; }
    public int Page { get; set; }
    public string ListType { get; set; }
}