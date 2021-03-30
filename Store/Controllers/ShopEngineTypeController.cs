using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.EngineDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Store.ActionFilters;
using Store.ModelBinders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopEngineTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ShopEngineTypeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetEngineTypes()
        {
            var engineTypes = await _repository.ShopEngineType.GetAllEngineTypes(trackChanges: false);
            var engineTypesDTO = _mapper.Map<IEnumerable<EngineDto>>(engineTypes);
            return Ok(engineTypesDTO);
        }

        [HttpGet("{id}" , Name = "EngineById")]
        public async Task<IActionResult> GetEngineForModel(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null) 
            {
                return NotFound(); 
            }

            var engineType = await _repository.ShopEngineType.GetEngineType(model.engineTypeId, trackChanges: false);
            var engineTypeDTO = _mapper.Map<EngineDto>(engineType);
            return Ok(engineTypeDTO);
        }

        [HttpGet("collection/({ids})", Name = "EngineCollection")]
        public async Task<IActionResult> GetEngineCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var engineEntities = await _repository.ShopEngineType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != engineEntities.Count())
            {
                return NotFound();
            }

            var engineToReturn = _mapper.Map<IEnumerable<EngineDto>>(engineEntities);
            return Ok(engineToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateEngineCollection([FromBody] IEnumerable<EngineDto> engineCollection)
        {
            if (engineCollection == null)
            {
                return BadRequest("engineCollection parameter was null");
            }

            var engineEntities = _mapper.Map<IEnumerable<ShopEngineType>>(engineCollection);
            foreach (var engine in engineEntities)
            {
                _repository.ShopEngineType.CreateEngineType(engine);
            }
            
            await _repository.SaveAsync();
            var engineCollectionToReturn = _mapper.Map<IEnumerable<EngineDto>>(engineEntities);
            var ids = string.Join(",", engineCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("EngineCollection", new { ids }, engineCollectionToReturn);
        }
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEngine([FromBody]EngineForCreationDto engine)
        {
            var engineEntity = _mapper.Map<ShopEngineType>(engine);
            _repository.ShopEngineType.CreateEngineType(engineEntity);
            await _repository.SaveAsync();

            var engineTypeToReturn = _mapper.Map<EngineDto>(engineEntity);
            return CreatedAtRoute("EngineById", new { id = engineTypeToReturn.id }, engineTypeToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEngine(int id)
        {
            var engine = await _repository.ShopEngineType.GetEngineType(id, trackChanges: false);
            if (engine == null)
            {
                return NotFound();
            }

            _repository.ShopEngineType.DeleteEngineType(engine);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMark(int id, [FromBody] EngineForUpdatingDto engine)
        {
            var engineEntity = await _repository.ShopEngineType.GetEngineType(id, trackChanges: true);
            if (engineEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(engine, engineEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
