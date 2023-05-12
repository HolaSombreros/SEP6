[assembly: FunctionsStartup(typeof(AzureFunctions.Startup))]
namespace AzureFunctions; 

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddScoped<IUserService,UserService>();
        builder.Services.AddDbContext<MoviemanagementDbContext>();
        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }
}