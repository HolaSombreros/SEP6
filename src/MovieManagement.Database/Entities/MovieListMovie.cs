namespace MovieManagement.Database.Entities;

[Table("MovieListMovie")]
public class MovieListMovie
{
    public Guid MovieListId { get; set; }

    public int MovieId { get; set; }

    public virtual MovieEntity MovieEntity { get; set; }

    public virtual MovieListEntity Movielist { get; set; }
}
