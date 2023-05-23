using MovieManagement.Domain.Models;

namespace MovieManagement.Models;

public class ReviewModel
{
    public Guid Id { get; set; }
    public int Rating { get; }
    public string? Text { get; }
    public DateOnly CreatedDate { get; }
    public User CreatedBy { get; }

    public ReviewModel(ReviewResponseDto reviewDto)
    {
        Id = reviewDto.Id;
        Rating = reviewDto.Rating;
        Text = reviewDto.Review;
        CreatedDate = DateOnly.FromDateTime(reviewDto.CreatedDate);
        CreatedBy = new User
        {
            UserId = reviewDto.CreatedBy.UserId,
            Username = reviewDto.CreatedBy.Username
        };
    }
}
