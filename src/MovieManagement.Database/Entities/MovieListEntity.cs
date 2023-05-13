namespace MovieManagement.Database.Entities;

[Table("MovieList")]
public  class MovieListEntity
{
    public Guid MovielistId { get; set; }

    public Guid UserId { get; set; }

    public string Title { get; set; }

    public bool IsDeleted { get; set; }

    public virtual UserEntity UserEntity { get; set; }
}
