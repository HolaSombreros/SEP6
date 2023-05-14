var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureAppConfiguration(config =>
{
    config.SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
});
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAzureService, AzureService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<AuthenticationStateProvider, MovieManagementASP>();
builder.Services.AddAutoMapper(typeof(MovieMapper).Assembly);
builder.Services.Configure<ApiConfig>(builder.Configuration.GetSection(ApiConfig.Section));
builder.Services.Configure<AzureFunctionsConfig>(builder.Configuration.GetSection(AzureFunctionsConfig.Section));
builder.Services.AddSingleton(new JsonSerializerOptions {
    PropertyNameCaseInsensitive = true,
    WriteIndented = true
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();