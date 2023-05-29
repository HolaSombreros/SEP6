namespace MovieManagement.Database.Repositories; 

public class ActorRepository : IActorRepository {
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<ActorEntity?> _repository;

    public ActorRepository(MovieManagementDbContext context, IRepository<ActorEntity?> repository) {
        _context = context;
        _repository = repository;
    }

    public async Task<ActorEntity?> AddActorAsync(ActorEntity actorEntity) {
        return await _repository.AddAsync(actorEntity);
    }

    public async Task<ActorEntity?> UpdateActorAsync(ActorEntity actorEntity) {
        var updatedResult = _context.Actors.Update(actorEntity!);
        await _context.SaveChangesAsync();
        return updatedResult.Entity;
    }

    public async Task<ActorEntity?> GetActorAsync(int id) {
        return await _context.Actors.FindAsync(id);
    }

    public async Task<List<string>> GetAgesByMovieAsync(int movieId) {
        return await (from actors in _context.Actors
            join movieActors in _context.MovieActors on actors.ActorId equals movieActors.ActorId
            where movieActors.MovieId == movieId && actors.Birthdate != null
            select new string(actors.Birthdate.ToString())).ToListAsync();
    }
    
    public async Task<List<int>> GetGenderForActorsInMainRoleByGenre(int genreId) {
        var list = new List<int>();
        
        if(genreId != 0) {
            list =  await (from actors in _context.Actors
                join movieActors in _context.MovieActors on actors.ActorId equals movieActors.ActorId
                join movies in _context.Movies on movieActors.MovieId equals movies.MovieId
                join movieGenres in _context.MovieGenres on movies.MovieId equals movieGenres.MovieId
                where movieGenres.GenreId == genreId && movieActors.MovieOrder == 0
                select actors.Gender).ToListAsync();
        }
        else {
            list = await (from actors in _context.Actors
                join movieActors in _context.MovieActors on actors.ActorId equals movieActors.ActorId
                join movies in _context.Movies on movieActors.MovieId equals movies.MovieId
                where movieActors.MovieOrder == 0
                select actors.Gender).ToListAsync();
        }

        return list;
    }
}