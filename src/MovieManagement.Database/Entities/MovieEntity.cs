namespace MovieManagement.Database.Entities;

[Table("Movie")]
public class MovieEntity
{
    [Key]
    public int MovieId { get; set; }
    public string? Title { get; set; }
    public DateTime? ReleaseDate { get; set; }
    public string? PosterUrl { get; set; }
    public virtual ICollection<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();
}
