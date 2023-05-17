namespace MovieManagement.Database.Repositories; 

public interface IRepository<TEntity> {
    Task<TEntity?> GetAsync(Guid id);
    Task<TEntity?> AddAsync(TEntity entity);
    Task<TEntity?> UpdateAsync(TEntity entity);
    Task DeleteAsync(Guid id);
}