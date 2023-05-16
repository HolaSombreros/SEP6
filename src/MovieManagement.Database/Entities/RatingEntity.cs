namespace MovieManagement.Database.Entities;

[Table("Rating")]
public class RatingEntity
{
    [Key]
    public Guid RatingId { get; set; }

    [Key]
    public Guid UserId { get; set; }

    public decimal? Rating { get; set; }

    public string Review { get; set; } = default!;

    public byte[] Datetime { get; set; } = default!;

    public bool IsDeleted { get; set; } = default!;
    public virtual MovieEntity MovieEntity { get; set; } = default!;

    public virtual UserEntity UserEntity { get; set; } = default!;
}
