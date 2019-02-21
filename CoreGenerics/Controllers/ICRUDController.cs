using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreGenerics.Web
{
    public interface ICRUDController<TModel, TId> 
        where TModel:class
        where TId : struct
    {
        Task<IActionResult> Add(TModel model);
        Task<IActionResult> Delete(TId id);
        Task<IActionResult> GetAll();
        Task<IActionResult> GetBy(Expression<Func<TModel, bool>> condition);
        Task<IActionResult> Update(TModel model);
    }
}
