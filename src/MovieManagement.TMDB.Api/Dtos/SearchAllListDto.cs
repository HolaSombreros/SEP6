namespace MovieManagement.TMDB.Api.Dtos;

public class SearchAllListDto
{
    [JsonPropertyName("total_pages")]
    public int TotalPages { get; set; }
    [JsonPropertyName("total_results")]
    public int TotalResults { get; set; }
    public List<SearchResultDto> Results { get; set; } = default!;
    public int Page { get; set; }
}