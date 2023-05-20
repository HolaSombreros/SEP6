namespace MovieManagement.FunctionDtos;

public class ReviewResponseDto
{
    public int Rating { get; set; }
    public string? Review { get; set; }
    public DateTime Created { get; set; }
    public UserDto CreatedBy { get; set; } = default!;
}
