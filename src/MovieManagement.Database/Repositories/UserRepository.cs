namespace MovieManagement.Database.Repositories; 

public class UserRepository : IUserRepository{
    private readonly MovieManagementDbContext _context;
    private readonly IRepository<UserEntity?> _repository;

    public UserRepository(MovieManagementDbContext context, IRepository<UserEntity?> repository) {
        _context = context;
        _repository = repository;
    }

    public async Task<UserEntity?> GetByEmail(string email) {
        return await _context.Users.FirstOrDefaultAsync(u => u!.Email.Equals(email) && !u.IsDeleted);
    }

    public async Task<UserEntity?> GetByUsername(string username) {
        return await _context.Users.FirstOrDefaultAsync(u => u!.Username.Equals(username) && !u.IsDeleted);
    }

    public async Task<UserEntity?> GetAsync(Guid id) {
       return await _repository.GetAsync(id);
    }

    public async Task<UserEntity?> AddAsync(UserEntity? entity) {
        return await _repository.AddAsync(entity);
    }

    public async Task<UserEntity?> UpdateAsync(UserEntity? entity) {
        return await _repository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(Guid id) {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId.Equals(id) && !u.IsDeleted);
        if (user is not null) {
            user!.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }
}