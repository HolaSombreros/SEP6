namespace MovieManagement.Database.Repositories; 

public class Repository <TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MovieManagementDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public Repository(MovieManagementDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetAsync(Guid? id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        var result = await _dbSet.AddAsync(entity);
        await SaveAsync();
        return result.Entity;
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity, Guid id)
    {
        var updatedResult = _dbSet.Update(entity!);
        await SaveAsync();
        return updatedResult.Entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        var result = await _dbSet.FindAsync(id);
        _dbSet.Remove(result!);
        await SaveAsync();
    }

    private async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}