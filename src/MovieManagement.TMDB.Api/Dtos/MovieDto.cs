namespace MovieManagement.TMDB.Api.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public int Budget { get; set; }
    public int Revenue { get; set; }
    public string? Title { get; set; }
    [JsonPropertyName("release_date")] 
    public string? ReleaseDate { get; set; }
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    [JsonPropertyName("overview")]
    public string? Description { get; set; }
    [JsonPropertyName("adult")]
    public bool IsAdult { get; set; }
    [JsonPropertyName("poster_path")] 
    public string? ImageUrl { get; set; }
}