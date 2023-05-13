namespace MovieManagement.Domain.Models;

public class Credits
{
    public IList<Cast> Cast { get; set; } = default!;
    public IList<Crew> Crew { get; set; } = default!;
}