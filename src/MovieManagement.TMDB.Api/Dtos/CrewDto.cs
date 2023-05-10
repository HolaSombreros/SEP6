namespace MovieManagement.TMDB.Api.Dtos;

public class CrewDto
{
    public int Id { get; set; }
    public string Department { get; set; } = default!;
    public string Name { get; set; } = default!;
    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = default!;
    public string Job { get; set; } = default!;
    public int Gender { get; set; }
    public double Popularity { get; set; }
    [JsonPropertyName("profile_path")]
    public string ImageUrl { get; set; } = default!;
}