using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RespositoryCore;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ryukote.Generics.Web
{
    [Route("api/[controller]")]
    [ApiController]
    class CRUDController<TModel, TId> : ControllerBase, ICRUDController<TModel, TId> 
        where TModel : class
        where TId : struct
    {
        private DbContext _context;
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TModel model)
        {
            try
            {
                Repository<TModel, TId, DbContext> repository = new Repository<TModel, TId, DbContext>(new DbContext(null));

                if (await repository.AddAsync(model) == 0)
                {
                    return BadRequest("Something is wrong in the model or in connection to the database.");
                }

                return Ok("Data is saved.");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(TId id)
        {
            Repository<TModel, TId, DbContext> repository = new Repository<TModel, TId, DbContext>(new DbContext(null));

            try
            {
                await repository.DeleteAsync(id);
                return Ok($"Item with identifier value of {id} is deleted.");
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Repository<TModel, TId, DbContext> repository = new Repository<TModel, TId, DbContext>(new DbContext(null));

            try
            {
                var results = await repository.GetAllAsync();
                return Ok(results);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBy(Expression<Func<TModel, bool>> condition)
        {
            Repository<TModel, TId, DbContext> repository = new Repository<TModel, TId, DbContext>(new DbContext(null));

            try
            {
                var results = await repository.GetByAsync(condition);
                return Ok(results);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TModel model)
        {
            try
            {
                Repository<TModel, TId, DbContext> repository = new Repository<TModel, TId, DbContext>(new DbContext(null));

                if (await repository.UpdateAsync(model) > 0)
                {
                    return Ok("Your values are updates.");
                }

                return BadRequest("Something is wrong with your model or with your database connection");
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
