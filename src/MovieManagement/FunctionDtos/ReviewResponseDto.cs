namespace MovieManagement.FunctionDtos;

public class ReviewResponseDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Review { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = default!;
}
