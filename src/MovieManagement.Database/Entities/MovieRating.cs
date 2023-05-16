namespace MovieManagement.Database.Entities;

[Table("MovieRating")]
public class MovieRating
{
    [Key]
    public int MovieId { get; set; }

    [Key]
    public Guid RatingId { get; set; }

    public virtual MovieEntity MovieEntity { get; set; } = default!;

    public virtual RatingEntity RatingEntity { get; set; } = default!;
}
