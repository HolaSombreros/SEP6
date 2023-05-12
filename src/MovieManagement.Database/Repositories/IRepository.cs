namespace MovieManagement.Database.Repositories; 

public interface IRepository<TEntity> {
    public Task<TEntity?> GetAsync(Guid id);
    public Task<TEntity?> AddAsync(TEntity entity);
    public Task<TEntity?> UpdateAsync(TEntity entity);
    public Task<TEntity> DeleteAsync(Guid id);
}