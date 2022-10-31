using System.Linq.Expressions;
using CjApp.IRepository;
using CjApp.IService;

namespace CjApp.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class, new()
    {
        //从子类构造函数传入
        protected IBaseRepository<TEntity> _iBaseRepository;

        public async Task<bool> CreateAsync(TEntity entity)
        {
            return await _iBaseRepository.CreateAsync(entity);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _iBaseRepository.DeleteAsync(id);
        }

        public async Task<bool> EditAsync(TEntity entity)
        {
            return await _iBaseRepository.EditAsync(entity);
        }

        public async Task<TEntity> FindAsync(string id)
        {
            return await _iBaseRepository.FindAsync(id);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _iBaseRepository.FindAsync(func);
        }

        public async Task<List<TEntity>> QueryAsync()
        {
            return await _iBaseRepository.QueryAsync();
        }

        public async Task<List<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> func)
        {
            return await _iBaseRepository.QueryAsync(func);
        }

        public async Task<bool> CreateBulkAsync(List<TEntity> entities)
        {
            return await _iBaseRepository.CreateBulkAsync(entities);
        }
    }
}