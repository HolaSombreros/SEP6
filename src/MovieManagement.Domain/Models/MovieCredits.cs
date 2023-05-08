namespace MovieManagement.Domain.Models;

public class MovieCredits
{
    public IList<MovieCast> MovieCast { get; set; } = default!;
    public IList<MovieCrew> MovieCrew { get; set; } = default!;
}