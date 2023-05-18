namespace MovieManagement.Database.Entities;

[Table("MovieList")]
public  class MovieListEntity
{
    public Guid MovieListId { get; set; }
    public Guid UserId { get; set; }
    public string Title { get; set; } = default!;
    public virtual UserEntity UserEntity { get; set; } = default!;
}
