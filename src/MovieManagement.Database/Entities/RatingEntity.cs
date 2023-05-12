namespace MovieManagement.Database.Entities;

[Table("Rating")]
public class RatingEntity
{
    [Key]
    public Guid RatingId { get; set; }

    [Key]
    public Guid UserId { get; set; }

    public decimal? Rating { get; set; }

    public string Review { get; set; }

    public byte[] Datetime { get; set; }

    public bool IsDeleted { get; set; }

    public virtual UserEntity UserEntity { get; set; }
}
