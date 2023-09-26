using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vkp.Base.Model;
using Vkp.Data.Repository;

namespace Vkp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericController<TEntity> : ControllerBase where TEntity : BaseModel
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericController(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetEntities()
        {
            var entities = await _repository.GetAllAsync();
            return Ok(entities);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetEntity(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }


        [HttpPost]
        public async Task<ActionResult<TEntity>> PostEntity(TEntity entity)
        {
            await _repository.AddAsync(entity);
            return CreatedAtAction(nameof(GetEntity), new { id = entity.Id }, entity);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }
            await _repository.UpdateAsync(entity);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEntity(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
