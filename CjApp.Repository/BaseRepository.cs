using System.Linq.Expressions;
using CjApp.IRepository;
using SqlSugar;
using SqlSugar.IOC;

namespace CjApp.Repository;

public class BaseRepository<TEntity> : SimpleClient<TEntity>, IBaseRepository<TEntity> where TEntity : class, new()
{
    protected BaseRepository(ISqlSugarClient context = null) : base(context)
    {
        Context = DbScoped.Sugar;
    }

    public async Task<bool> CreateAsync(TEntity entity)
    {
        return await base.InsertAsync(entity);
    }

    public async Task<bool> DeleteAsync(string id)
    {
        return await base.DeleteByIdAsync(id);
    }

    public async Task<bool> EditAsync(TEntity entity)
    {
        return await base.UpdateAsync(entity);
    }

    public async Task<TEntity> FindAsync(string id)
    {
        return await base.GetByIdAsync(id);
    }

    public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
    {
        return await base.GetSingleAsync(func);
    }

    public async Task<List<TEntity>> QueryAsync()
    {
        return await base.GetListAsync();
    }

    public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
    {
        return await base.GetListAsync(func);
    }

    public async Task<bool> CreateBulkAsync(List<TEntity> entities)
    {
        return await base.InsertRangeAsync(entities);
    }
}