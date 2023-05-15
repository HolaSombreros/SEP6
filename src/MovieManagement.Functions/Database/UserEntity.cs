namespace MovieManagement.Functions.Database; 

public class UserEntity {
    public Guid user_id { get; set; }

    public string username { get; set; } = default!;
    
    public string email { get; set; } = default!;

    public string password { get; set; } = default!;

    public bool is_deleted { get; set; }
}