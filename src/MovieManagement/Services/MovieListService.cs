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

    public MovieListViewModel GetCustomList(Guid listId)
    {
        var list = _movieLists.FirstOrDefault(list => list.Id == listId);
        return list ?? new MovieListViewModel();
    }

    public async Task AddMovieToListAsync(Guid listId, MovieViewModel movie)
    {
        var list = GetCustomList(listId);
        if (list != new MovieListViewModel())
        {
            list.Movies.Add(movie);
            await _service.PostAsync<MovieListDto>(_settings.AddToCustomList, listId + "/" + movie.Id);
            NotifyChanged();
        }
    }

    public async Task DeleteMovieFromListAsync(Guid listId, MovieViewModel movie)
    {
        var list = GetCustomList(listId);
        if (list != new MovieListViewModel())
        {
            list.Movies.Remove(movie);
            await _service.DeleteFromRouteAsync(_settings.AddToCustomList, listId + "/" + movie.Id);
            NotifyChanged();
        }
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
        var list = GetCustomList(id);
        if (list != new MovieListViewModel())
        {
            await _service.DeleteFromRouteAsync(_settings.DeleteCustomList, id.ToString());
            _movieLists.Remove(list);
            NotifyChanged();
        }
    }

    public async Task GetUserListsAsync(Guid userId)
    {
        try
        {
            var lists = await _service.GetFromRouteAsync<List<MovieListDto>>(_settings.CreateCustomList, userId);
            _movieLists = lists.Select(listDto => new MovieListViewModel(listDto)).ToList();
            NotifyChanged();
        }
        catch (Exception)
        {
            _movieLists = new List<MovieListViewModel>();
            NotifyChanged();
        }
       
    }

    private void NotifyChanged()
    {
        OnChanged?.Invoke(this, EventArgs.Empty);
    }
}