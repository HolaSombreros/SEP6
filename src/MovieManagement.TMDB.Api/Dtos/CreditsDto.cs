namespace MovieManagement.TMDB.Api.Dtos;

public class CreditsDto
{
    [JsonPropertyName("cast")]
    public IList<CastDto>? MovieCast { get; set; }
    [JsonPropertyName("crew")]
    public IList<CrewDto>? MovieCrew { get; set; }
}