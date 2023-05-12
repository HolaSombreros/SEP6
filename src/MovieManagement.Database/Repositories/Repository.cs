using MovieManagement.Database.Context;

namespace MovieManagement.Database.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly MovieManagementDbContext _context;
    private readonly DbSet<TEntity?> _dbSet;

    public Repository(MovieManagementDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity?> GetAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity?> AddAsync(TEntity entity)
    {
        var result = await _dbSet.AddAsync(entity);
        await SaveAsync();
        return result.Entity;
    }

    public async Task<TEntity?> UpdateAsync(TEntity entity)
    {
        var result = await _dbSet.FindAsync(entity);
        var updatedResult = _dbSet.Update(result);
        await SaveAsync();
        return updatedResult.Entity;
    }

    public async Task<TEntity> DeleteAsync(Guid id)
    {
        var result = await _dbSet.FindAsync(id);
        _dbSet.Remove(result);
        await SaveAsync();
        return result;
    }

    private async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}