[assembly: FunctionsStartup(typeof(MovieManagement.Functions.Startup))]
namespace MovieManagement.Functions; 

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddDbContext<MovieManagementDbContext>(options =>
            options.UseSqlServer(config["DbConnectionString"]));
        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}