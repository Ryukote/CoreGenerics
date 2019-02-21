using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ryukote.Generics.Web
{
    public class Repository<TModel, TId, TDbContext> : IRepository<TModel, TId>
        where TModel : class //TModel is generic model
        where TId : struct //TId is generic type for id in the model
        where TDbContext : DbContext //TDbContext is our DbContext that is derived from DbContext
    {
        private readonly TDbContext _dbContext;

        public Repository(TDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddAsync(TModel model)
        {
            await _dbContext.Set<TModel>().AddAsync(model);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TId id)
        {
            var entity = await GetByAsync(condition => condition.Equals(id));
            _dbContext.Set<TModel>().Remove(entity.FirstOrDefault());
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await _dbContext.Set<TModel>().ToListAsync();
        }

        public async Task<IEnumerable<TModel>> GetByAsync(Expression<Func<TModel, bool>> condition)
        {
            return await _dbContext.Set<TModel>().Where(condition).ToListAsync();
        }

        public async Task<int> UpdateAsync(TModel model)
        {
            _dbContext.Set<TModel>().Update(model);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
