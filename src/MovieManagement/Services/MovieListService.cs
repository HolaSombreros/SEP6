namespace MovieManagement.Services;

public class MovieListService : IMovieListService
{
    private static  List<MovieListViewModel> _movieLists = default!;
    private readonly IAzureService _service;
    private readonly AzureFunctionsConfig _settings;
    public event EventHandler<EventArgs>? OnChanged;

    public MovieListService(IAzureService service, IOptions<AzureFunctionsConfig> settings)
    {
        _service = service;
        _settings = settings.Value;
    }

    public List<MovieListViewModel> GetCurrentUserLists()
    {
        return _movieLists;
    }

    public async Task CreateCustomListAsync(MovieListViewModel list)
    {
        var newList = new MovieListDto(list);
        var listDto = await _service.PostAsync<MovieListDto>(_settings.CreateCustomList, newList);
        list.Id = listDto.Id;
        _movieLists.Add(list);
        NotifyChanged();
    }

    public async Task DeleteCustomListAsync(Guid id)
    {
        await _service.DeleteFromRouteAsync(_settings.DeleteCustomList, id.ToString());
        var list = _movieLists.SingleOrDefault(list => list.Id == id);
        if (list != null)
        {
            _movieLists.Remove(list);
        }
        NotifyChanged();
    }

    public async Task GetUserListsAsync(Guid id)
    {
        var lists = await _service.GetFromRouteAsync<List<MovieListDto>>(_settings.CreateCustomList, id);
        _movieLists = lists.Select(listDto => new MovieListViewModel(listDto)).ToList();
        NotifyChanged();
    }

    public void NotifyChanged()
    {
        OnChanged?.Invoke(this, EventArgs.Empty);
    }
}