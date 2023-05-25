namespace MovieManagement.FunctionDtos;

public class RatingDto
{
    public MovieDto MovieDto { get; set; } = default!;
    public int Rating { get; set; }
    public string? Review { get; set; }
    public Guid UserId { get; set; }
    public Guid RatingId { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;

}
