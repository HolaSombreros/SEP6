namespace MovieManagement.Services;

public class MovieListService : IMovieListService
{
    private static  List<MovieListViewModel> _movieLists = default!;
    private readonly IAzureService _service;
    private readonly AzureFunctionsConfig _settings;
    public event Action? OnChanged;

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
        try
        {
            if (list != new MovieListViewModel())
            {
                list.Movies.Add(movie);
                var movieDto = new MovieDto(movie);
                await _service.PutAsync<MovieListDto>(_settings.AddToCustomList + "/" + listId, movieDto);
                OnChanged?.Invoke();
            }
        }
        catch (Exception)
        {
            await GetUserListsAsync(list.UserId);
        }
    }

    public async Task DeleteMovieFromListAsync(Guid listId, MovieViewModel movie)
    {
        var list = GetCustomList(listId);
        try
        {
            if (list != new MovieListViewModel())
            {
                list.Movies.Remove(movie);
                await _service.DeleteFromRouteAsync(_settings.DeleteFromCustomList, listId + "/" + movie.Id);
                OnChanged?.Invoke();
            }
        }
        catch (Exception)
        {
            await GetUserListsAsync(list.UserId);
        }
    }

    public async Task CreateCustomListAsync(MovieListViewModel list)
    {
        var newList = new MovieListDto(list);
        var listDto = await _service.PostAsync<MovieListDto>(_settings.CreateCustomList, newList);
        list.Id = listDto.MovieListId;
        _movieLists.Add(list);
        OnChanged?.Invoke();
    }

    public async Task DeleteCustomListAsync(Guid id)
    {
        var list = GetCustomList(id);
        if (list != new MovieListViewModel())
        {
            await _service.DeleteFromRouteAsync(_settings.DeleteCustomList, id.ToString());
            _movieLists.Remove(list);
            OnChanged?.Invoke();
        }
    }

    public async Task GetUserListsAsync(Guid userId)
    {
        try
        {
            var lists = await _service.GetFromRouteAsync<List<MovieListDto>>(_settings.GetCustomLists, userId);
            _movieLists = lists.Select(listDto => new MovieListViewModel(listDto)).ToList();
            OnChanged?.Invoke();
        }
        catch (Exception)
        {
            _movieLists = new List<MovieListViewModel>();
            OnChanged?.Invoke();
        }
       
    }
}