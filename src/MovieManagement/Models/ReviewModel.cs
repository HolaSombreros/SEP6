namespace MovieManagement.Models;

public class ReviewModel
{
    public Guid Id { get; set; }
    public int Rating { get; }
    public string? Text { get; }
    public DateOnly CreatedDate { get; }
    public string CreatedBy { get; } = null!;

    public ReviewModel(ReviewResponseDto reviewDto)
    {
        Id = reviewDto.Id;
        Rating = reviewDto.Rating;
        Text = reviewDto.Review;
        CreatedDate = DateOnly.FromDateTime(reviewDto.CreatedDate);
        CreatedBy = reviewDto.CreatedBy;
    }

    public ReviewModel()
    {
    }
}
