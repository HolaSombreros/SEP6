namespace MovieManagement.TMDB.Api.Dtos;

public class CreditsDto
{
    public IList<CastDto> Cast { get; set; } = default!;
    public IList<CrewDto> Crew { get; set; } = default!;
}