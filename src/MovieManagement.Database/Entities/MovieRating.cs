namespace MovieManagement.Database.Entities;

[Table("MovieRating")]
public partial class MovieRating
{
    [Key]
    public int MovieId { get; set; }

    [Key]
    public Guid RatingId { get; set; }

    public virtual MovieEntity MovieEntity { get; set; }

    public virtual RatingEntity RatingEntity { get; set; }
}
