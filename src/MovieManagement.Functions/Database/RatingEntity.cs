namespace MovieManagement.Functions.Database;

public class RatingEntity
{
    public Guid rating_id { get; set; }
    public int rating { get; set; }
    public string review { get; set; } = default!;
    public bool is_deleted { get; set; }
    public Guid user_id { get; set; }
}