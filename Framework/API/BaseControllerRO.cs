
namespace Framework.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseControllerRO<TDto, TDtoGrid, TEntity, TEntityId, IService>
        where TDto : class, IBaseDtoEntity<TEntityId>
        where TDtoGrid : class
        where TEntity : class, IBaseEntity<TEntityId>
        where IService : IBaseService<TEntity, TEntityId>
    {

        private readonly IBaseService<T> _baseService;

        public BaseControllerRO(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            try
            {
                var entities = await _baseService.GetAllAsync();
                return Ok(entities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var entity = await _baseService.GetByIdAsync(id);

                if (entity == null)
                {
                    return NotFound($"Entity with ID {id} not found");
                }

                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] T entity)
        {
            try
            {
                var createdEntity = await _baseService.CreateAsync(entity);
                return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Update(Guid? id, [FromBody] T entity)
        {
            try
            {
                var updatedEntity = await _baseService.UpdateAsync(id, entity);

                if (updatedEntity == null)
                {
                    return NotFound($"Entity with ID {id} not found");
                }

                return Ok(updatedEntity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var isDeleted = await _baseService.DeleteAsync(id);

                if (!isDeleted)
                {
                    return NotFound($"Entity with ID {id} not found");
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}  
