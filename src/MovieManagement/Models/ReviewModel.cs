namespace MovieManagement.Models;

public class ReviewModel
{
    public int Rating { get; }
    public string? Text { get; }
    public DateOnly CreatedDate { get; }
    public string CreatedBy { get; }

    public ReviewModel(ReviewResponseDto reviewDto)
    {
        Rating = reviewDto.Rating;
        Text = reviewDto.Review;
        CreatedDate = DateOnly.FromDateTime(reviewDto.CreatedDate);
        CreatedBy = reviewDto.CreatedBy;
    }
}
