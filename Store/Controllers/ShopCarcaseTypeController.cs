using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.CarcaseDTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.ActionFilters;
using Store.ModelBinders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopCarcaseTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ShopCarcaseTypeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCarcaseTypes()
        {
            var carcases = await _repository.ShopCarcaseType.GetAllCarcaseTypes(trackChanges: false);
            var carcasesDTO = _mapper.Map<IEnumerable<CarcaseDto>>(carcases);
            return Ok(carcasesDTO);
        }

        [HttpGet("{id}", Name = "CarcaseTypeById")]
        public async Task<IActionResult> GetCarcase(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var carcase = await _repository.ShopCarcaseType.GetCarcaseType(id, trackChanges: false);
            var carcaseDTO = _mapper.Map<CarcaseDto>(carcase);
            return Ok(carcaseDTO);
        }

        [HttpGet("collection/({ids})", Name = "CarcaseCollection")]
        public async Task<IActionResult> GetCarcaseCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var carcaseEntities = await _repository.ShopCarcaseType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != carcaseEntities.Count())
            {
                return NotFound();
            }

            var carcaseToReturn = _mapper.Map<IEnumerable<CarcaseDto>>(carcaseEntities);
            return Ok(carcaseToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateDriveCollection([FromBody] IEnumerable<CarcaseDto> carcaseCollection)
        {
            if (carcaseCollection == null)
            {
                return BadRequest("carcaseCollection parameter was null");
            }

            var carcaseEntities = _mapper.Map<IEnumerable<ShopCarcaseType>>(carcaseCollection);
            foreach (var carcase in carcaseEntities)
            {
                _repository.ShopCarcaseType.CreateCarcaseType(carcase);
            }

            await _repository.SaveAsync();
            var carcaseCollectionToReturn = _mapper.Map<IEnumerable<CarcaseDto>>(carcaseEntities);
            var ids = string.Join(",", carcaseCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("CarcaseCollection", new { ids }, carcaseCollectionToReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCarcase([FromBody]CarcaseForCreationDto carcaseType)
        {
            var carcaseEntity = _mapper.Map<ShopCarcaseType>(carcaseType);
            _repository.ShopCarcaseType.CreateCarcaseType(carcaseEntity);
            await _repository.SaveAsync();

            var carcaseTypeToReturn = _mapper.Map<CarcaseDto>(carcaseEntity);
            return CreatedAtRoute("CarcaseTypeById", new { id = carcaseTypeToReturn.id }, carcaseTypeToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCarcaseType(int id, [FromBody] CarcaseForUpdatingDto carcase)
        {
            var carcaseEntity = await _repository.ShopCarcaseType.GetCarcaseType(id, trackChanges: true);
            if (carcaseEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(carcase, carcaseEntity);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarcaseType(int id)
        {
            var carcase = await _repository.ShopCarcaseType.GetCarcaseType(id, trackChanges: false);
            if (carcase == null)
            {
                return NotFound();
            }

            _repository.ShopCarcaseType.DeleteCarcaseType(carcase);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
