namespace MovieManagement.Models;

public class ReviewModel
{
    public Guid Id { get; set; }
    public int Rating { get; }
    public string? Text { get; }
    public DateOnly CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;

    public ReviewModel(ReviewResponseDto reviewDto)
    {
        Id = reviewDto.Id;
        Rating = reviewDto.Rating;
        Text = reviewDto.Review;
        CreatedDate = DateOnly.FromDateTime(reviewDto.CreatedDate);
        CreatedBy = reviewDto.CreatedBy;
    }

    public ReviewModel(RatingDto dto)
    {
        Id = dto.RatingId!;
        Rating = dto.Rating;
        Text = dto.Review;
        CreatedDate = DateOnly.FromDateTime(dto.CreatedDate);
        CreatedBy = dto.CreatedBy;
    }

    public ReviewModel()
    {
    }
}
