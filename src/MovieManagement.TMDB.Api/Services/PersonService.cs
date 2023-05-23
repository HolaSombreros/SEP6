namespace MovieManagement.TMDB.Api.Services;

public class PersonService : IPersonService
{
    private readonly IService _service;
    private readonly IMapper _mapper;
    private readonly ApiConfig _settings;
    
    public PersonService(IService service, IMapper mapper, IOptions<ApiConfig> settings)
    {
        _service = service;
        _mapper = mapper;
        _settings = settings.Value;
    }

    public async Task<Credits> GetPersonCreditsAsync(int id)
    {
        try
        {
            var personCreditsDto = await _service.GetAsync<CreditsDto>(_settings.PersonPath + id + _settings.MovieCredits + _settings.QueryBuilder);
            return _mapper.Map<CreditsDto, Credits>(personCreditsDto);
        }
        catch
        {
            return new Credits();
        }
    }

    public async Task<Person> GetPersonDetailsAsync(int id)
    {
        try
        {
            var personDetailsDto = await _service.GetAsync<PersonDto>(_settings.PersonPath + id + _settings.QueryBuilder);
            return _mapper.Map<PersonDto, Person>(personDetailsDto);
        }
        catch
        {
            return new Person();
        }
    }
}