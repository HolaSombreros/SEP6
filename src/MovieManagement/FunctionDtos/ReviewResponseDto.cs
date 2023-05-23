using MovieManagement.Domain.Models;

namespace MovieManagement.FunctionDtos;

public class ReviewResponseDto
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string? Review { get; set; }
    public DateTime CreatedDate { get; set; }
    public UserDto CreatedBy { get; set; } = default!;
}
