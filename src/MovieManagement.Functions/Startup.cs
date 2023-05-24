[assembly: FunctionsStartup(typeof(MovieManagement.Functions.Startup))]
namespace MovieManagement.Functions; 

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IValidator<MovieDto>, MovieDtoValidator>();
        builder.Services.AddScoped<IValidator<RatingDto>, RatingDtoValidator>();
        builder.Services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
        builder.Services.AddScoped<IValidator<GetRatingDto>, GetRatingDtoValidator>();
        builder.Services.AddScoped<IValidator<LoginUserDto>, LoginUserDtoValidator>();
        builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        builder.Services.AddScoped<IRatingService, RatingService>();
        builder.Services.AddScoped<IMovieService, MovieService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IValidator<RatingDto>, RatingDtoValidator>();
        builder.Services.AddDbContext<MovieManagementDbContext>(options =>
            options.UseSqlServer(config["DbConnectionString"]));
        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRatingRepository, RatingRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
    }
}