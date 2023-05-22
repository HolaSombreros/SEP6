namespace MovieManagement.Database.Repositories; 

public class UserRepository : IUserRepository{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<UserEntity?> _repository;

    public UserRepository(MovieManagementDbContext context, IRepository<UserEntity?> repository) {
        _context = context;
        _repository = repository;
    }

    public async Task<UserEntity?> GetByEmail(string email) {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
    }

    public async Task<UserEntity?> GetByUsername(string username) {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username.Equals(username));
    }

    public async Task<IList<UserEntity?>> GetUsers(IList<Guid> ids)
    {
        return (await _context.Users
            .Where(u => ids.Contains(u.UserId))
            .ToListAsync())!;
    }

    public async Task<UserEntity?> GetAsync(Guid id) {
       return await _repository.GetAsync(id);
    }

    public async Task<UserEntity?> AddAsync(UserEntity? entity) {
        return await _repository.AddAsync(entity);
    }

    public async Task<UserEntity?> UpdateAsync(UserEntity? entity, Guid id) {
        var existingUser = await GetAsync(id);
        if (existingUser is not null) {
            existingUser.Username = entity!.Username;
            existingUser.Email = entity.Email;
            if (!string.IsNullOrEmpty(entity.Password)) {
                existingUser.Password = entity.Password;
            }
        }

        await _context.SaveChangesAsync();
        return existingUser;
    }

    public async Task DeleteAsync(Guid id) {
        await _repository.DeleteAsync(id);
    }
}