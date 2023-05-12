namespace MovieManagement.Database.Entities;

[Table("User")]
public class UserEntity
{
    public Guid UserId { get; set; }

    public string Username { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<MovieListEntity> MovieLists { get; set; } = new List<MovieListEntity>();

    public virtual ICollection<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();
}
