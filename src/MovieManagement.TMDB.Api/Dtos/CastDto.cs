namespace MovieManagement.TMDB.Api.Dtos;

public class CastDto
{
    public int Id { get; set; }
    public int Gender { get; set; }
    public string Name { get; set; } = default!;
    public double Popularity { get; set; }
    public string Character { get; set; } = default!;
    public int Order { get; set; }
    [JsonPropertyName("original_name")]
    public string OriginalName { get; set; } = default!;
    [JsonPropertyName("profile_path")]
    public string? ImageUrl { get; set; } = default!;
}