namespace MovieManagement.Database.Config;

public class DatabaseConfig
{
    public static string Section { get; set; } = "DatabaseConnection";
    public string ConnectionString { get; set; } = default!;
}