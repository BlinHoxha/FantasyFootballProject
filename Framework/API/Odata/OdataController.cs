using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Framework.API.Odata
{
    public abstract class BaseODataController<TEntity, TKey> : ODataController where TEntity : class
    {
        private readonly IBaseService<T> _baseService;

        public BaseODataController(DbContext context)
        {
            _baseService = baseService;
        }

        // GET: odata/Entities
        [HttpGet]
        public virtual IActionResult GetAll()
        {
            return Ok(_dbSet);
        }

        // GET: odata/Entities(key)
        [HttpGet("{key}")]
        public virtual async Task<IActionResult> GetById([FromRoute] TKey key)
        {
            var entity = await _dbSet.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        // Additional methods like Post, Put, Delete can be added here
    }
}
