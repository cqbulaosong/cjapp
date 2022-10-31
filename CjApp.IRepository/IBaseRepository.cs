using System.Linq.Expressions;
using SqlSugar;

namespace CjApp.IRepository;

public interface IBaseRepository<TEntity> where TEntity : class, new()
{
    Task<bool> CreateAsync(TEntity entity);
    Task<bool> DeleteAsync(string id);
    Task<bool> EditAsync(TEntity entity);
    Task<TEntity> FindAsync(string id);
    Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func);
    Task<List<TEntity>> QueryAsync();
    Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func);
    Task<bool> CreateBulkAsync(List<TEntity> entities);
}