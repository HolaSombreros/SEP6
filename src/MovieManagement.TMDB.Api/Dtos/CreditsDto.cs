namespace MovieManagement.TMDB.Api.Dtos;

public class CreditsDto
{
    public IList<CastDto>? Cast { get; set; }
    public IList<CrewDto>? Crew { get; set; }
}