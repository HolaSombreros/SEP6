namespace MovieManagement.TMDB.Api.Dtos;

public class MovieDto
{
    public int Id { get; set; }
    public int Budget { get; set; }
    public int Revenue { get; set; }
    public string Title { get; set; } = default!;
    [JsonPropertyName("release_date")] 
    public string ReleaseDate { get; set; } = default!;
    [JsonPropertyName("vote_average")]
    public double VoteAverage { get; set; }
    [JsonPropertyName("vote_count")]
    public int VoteCount { get; set; }
    [JsonPropertyName("overview")]
    public string Description { get; set; } = default!;
    [JsonPropertyName("adult")]
    public bool IsAdult { get; set; }
    [JsonPropertyName("poster_path")] 
    public string ImageUrl { get; set; } = default!;
    public IList<GenreDto> Genres { get; set; } = default!;
    [JsonPropertyName("runtime")]
    public int Length { get; set; }
    public double Popularity { get; set; }
    [JsonPropertyName("original_language")]
    public string OriginalLanguage { get; set; } = default!;
}