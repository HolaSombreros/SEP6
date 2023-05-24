namespace MovieManagement.Functions.Dtos;

public class RatingResultDto
{
    public int Page { get; set; }
    public int TotalResults { get; set; }
    public int TotalPages { get; set; }
    public IList<MovieRatingDto?>? MovieRatingDtos { get; set; }
}