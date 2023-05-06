namespace MovieManagement.TMDB.Api.Dtos;

public class MovieCreditsDto
{
    [JsonPropertyName("cast")]
    public IList<MovieCastDto>? MovieCast { get; set; }
    [JsonPropertyName("crew")]
    public IList<MovieCrewDto>? MovieCrew { get; set; }
}