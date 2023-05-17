namespace MovieManagement.TMDB.Api.Dtos;

public class SearchResultDto
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    [JsonPropertyName("media_type")]
    public string MediaType { get; set; } = default!;
    [JsonPropertyName("profile_path")]
    public string ProfilePath { get; set; } = default!;
    public string Title { get; set; } = default!;
    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; } = default!;
    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }
    [JsonPropertyName("known_for_department")]
    public string? KnownFor { get; set; }
}