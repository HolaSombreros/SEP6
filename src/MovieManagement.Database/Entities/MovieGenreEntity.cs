namespace MovieManagement.Database.Entities;
[Table("MovieGenre")]
public class MovieGenreEntity
{
    public int GenreId { get; set; }
    public int MovieId { get; set; }
    public virtual GenreEntity GenreEntity { get; set; } = default!;
    public virtual MovieEntity MovieEntity { get; set; } = default!;
}