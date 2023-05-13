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
    public string Title { get; set; } = default!;
    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = default!;
    [JsonPropertyName("overview")]
    public string Description { get; set; } = default!;
    [JsonPropertyName("poster_path")]
    public string PosterUrl { get; set; } = default!;
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    
}