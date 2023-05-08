namespace MovieManagement.TMDB.Api.Dtos;

public class MovieCrewDto
{
    public int Id { get; set; }
    public string? Department { get; set; }
    public string? Name { get; set; }
    [JsonPropertyName("original_name")]
    public string? OriginalName { get; set; }
    public string? Job { get; set; }
    public int Gender { get; set; }
    public double Popularity { get; set; }
    [JsonPropertyName("profile_path")]
    public string? ImageUrl { get; set; }
}