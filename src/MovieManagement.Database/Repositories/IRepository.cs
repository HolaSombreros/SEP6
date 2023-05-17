namespace MovieManagement.Database.Repositories; 

public interface IRepository<TEntity> {
    Task<TEntity?> GetAsync(Guid id);
    Task<TEntity?> AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity, Guid id);
    Task<TEntity> DeleteAsync(Guid id);
}