[assembly: FunctionsStartup(typeof(MovieManagement.Functions.Startup))]
namespace MovieManagement.Functions; 

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var config = new ConfigurationBuilder().AddEnvironmentVariables().Build();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IValidator<MovieDto>, MovieDtoValidator>();
        builder.Services.AddScoped<IValidator<MovieRatingDto>, MovieRatingDtoValidator>();
        builder.Services.AddScoped<IValidator<UserDto>, UserDtoValidator>();
        builder.Services.AddScoped<IValidator<GetRatingDto>, GetRatingDtoValidator>();
        builder.Services.AddScoped<IValidator<LoginUserDto>, LoginUserDtoValidator>();
        builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
        builder.Services.AddScoped<IValidator<MovieToMovieListDto>, AddMovieToMovieListValidator>();
        builder.Services.AddScoped<IValidator<ActorDto>, ActorValidator>();
        builder.Services.AddScoped<IValidator<AddMovieActorDto>, AddMovieActorValidator>();
        builder.Services.AddScoped<IRatingService, RatingService>();
        builder.Services.AddScoped<IMovieService, MovieService>();
        builder.Services.AddScoped<IGenreService, GenreService>();
        builder.Services.AddScoped<IStatisticsService, StatisticsService>();
        builder.Services.AddScoped<IMovieGenreService, MovieGenreService>();
        builder.Services.AddScoped<IValidator<AddMovieListDto>, AddMovieListValidator>();
        builder.Services.AddScoped<IValidator<GetRatingDto>, GetRatingDtoValidator>();
        builder.Services.AddDbContext<MovieManagementDbContext>(options =>
            options.UseSqlServer(config["DbConnectionString"]));
        builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
        builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IRatingRepository, RatingRepository>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        builder.Services.AddScoped<IGenreRepository, GenreRepository>();
        builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
        builder.Services.AddScoped<IMovieListRepository, MovieListRepository>();
        builder.Services.AddScoped<IMovieListService, MovieListService>();
        builder.Services.AddScoped<IMovieListMovieService, MovieListMovieService>();
        builder.Services.AddScoped<IMovieListMovieRepository, MovieListMovieRepository>();
        builder.Services.AddScoped<IActorService, ActorService>();
        builder.Services.AddScoped<IActorRepository, ActorRepository>();
        builder.Services.AddScoped<IMovieActorRepository, MovieActorRepository>();
        builder.Services.AddScoped<IMovieActorService, MovieActorService>();
    }
}