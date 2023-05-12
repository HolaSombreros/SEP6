[assembly: FunctionsStartup(typeof(AzureFunctions.Startup))]
namespace AzureFunctions; 

public class Startup : FunctionsStartup
{
    
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        
        builder.Services.AddScoped<IUserService,UserService>();
        builder.Services.AddDbContext<MoviemanagementDbContext>(options =>
            options.UseSqlServer(config["DbConnectionString"]));
        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }
}