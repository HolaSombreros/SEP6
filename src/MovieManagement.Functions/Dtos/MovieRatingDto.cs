namespace MovieManagement.Functions.Dtos;

public class MovieRatingDto
{
    public Guid RatingId { get; set; }
    public int Rating { get; set; }
    public string? Review { get; set; }
    public DateTime? CreatedDate { get; set; }
    public string? CreatedBy { get; set; }
    public MovieDto MovieDto { get; set; } = default!;
    public Guid? UserId { get; set; }
}