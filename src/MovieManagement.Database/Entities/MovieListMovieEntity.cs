namespace MovieManagement.Database.Entities;

[Table("MovieListMovie")]
public class MovieListMovieEntity
{
    public Guid MovieListId { get; set; }

    public int MovieId { get; set; }

    public virtual MovieEntity MovieEntity { get; set; } = default!;
    
    public virtual MovieListEntity MovieList { get; set; } = default!;
}
