using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ryukote.Generics.Web
{
    /// <summary>
    /// Generic interface for repository pattern.
    /// </summary>
    /// <typeparam name="T">Class that represents a table in database.</typeparam>
    /// <typeparam name="I">Struct that represents your id in a table. Usually int or Guid.</typeparam>
    public interface IRepository<TModel, TId>
        where TModel : class
        where TId : struct
    {
        /// <summary>
        /// Gets all the data asynchronously.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetAllAsync();
        /// <summary>
        /// Gets filtered data by lambda expression asynchronously.
        /// </summary>
        /// <param name="condition">Lambda expression for filtering.</param>
        /// <returns></returns>
        Task<IEnumerable<TModel>> GetByAsync(Expression<Func<TModel, bool>> condition);
        /// <summary>
        /// Inserting data in a table asynchronously.
        /// </summary>
        /// <param name="model">Generic model.</param>
        /// <returns></returns>
        Task<int> AddAsync(TModel model);
        /// <summary>
        /// Delete data from the table asynchronously.
        /// </summary>
        /// <param name="id">Id in a table.</param>
        /// <returns></returns>
        Task DeleteAsync(TId id);
        /// <summary>
        /// Update data in a table asynchronously.
        /// </summary>
        /// <param name="id">Id in a table.</param>
        /// <param name="model">Generic model.</param>
        /// <returns></returns>
        Task<int> UpdateAsync(TModel model);
    }
}
