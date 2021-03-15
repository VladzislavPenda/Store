using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.CarcaseDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store.ModelBinders;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult GetCarcaseTypes()
        {
            var carcases = _repository.ShopCarcaseType.GetAllCarcaseTypes(trackChanges: false);
            var carcasesDTO = _mapper.Map<CarcaseDTO>(carcases);
            return Ok(carcasesDTO);
        }

        [HttpGet("{id}", Name = "CarcaseTypeById")]
        public IActionResult GetCarcase(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var carcase = _repository.ShopCarcaseType.GetCarcaseType(model.carcaseTypeId, trackChanges: false);
            var carcaseDTO = _mapper.Map<CarcaseDTO>(carcase);
            return Ok(carcaseDTO);
        }

        [HttpGet("collection/({ids})", Name = "CarcaseCollection")]
        public IActionResult GetCarcaseCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var carcaseEntities = _repository.ShopCarcaseType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != carcaseEntities.Count())
            {
                return NotFound();
            }

            var carcaseToReturn = _mapper.Map<IEnumerable<CarcaseDTO>>(carcaseEntities);
            return Ok(carcaseToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateDriveCollection([FromBody] IEnumerable<CarcaseDTO> carcaseCollection)
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

            _repository.Save();
            var carcaseCollectionToReturn = _mapper.Map<IEnumerable<CarcaseDTO>>(carcaseEntities);
            var ids = string.Join(",", carcaseCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("CarcaseCollection", new { ids }, carcaseCollectionToReturn);
        }

        [HttpPost]
        public IActionResult CreateCarcase([FromBody]CarcaseForCreationDTO carcaseType)
        {
            if (carcaseType == null)
            {
                return BadRequest("CarcaseForCreationDTO object send from the client was null");
            }

            var carcaseEntity = _mapper.Map<ShopCarcaseType>(carcaseType);
            _repository.ShopCarcaseType.CreateCarcaseType(carcaseEntity);
            _repository.Save();

            var carcaseTypeToReturn = _mapper.Map<CarcaseDTO>(carcaseEntity);
            return CreatedAtRoute("CarcaseTypeById", new { id = carcaseTypeToReturn.id }, carcaseTypeToReturn);
        }
    }
}
