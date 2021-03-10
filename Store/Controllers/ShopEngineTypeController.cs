using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.EngineDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;
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
        public IActionResult GetEngineTypes()
        {
            var engineTypes = _repository.ShopEngineType.GetAllEngineTypes(trackChanges: false);
            var engineTypesDTO = _mapper.Map<IEnumerable<EngineDTO>>(engineTypes);
            return Ok(engineTypesDTO);
        }

        [HttpGet("{id}" , Name = "EngineById")]
        public IActionResult GetEngineForModel(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null) 
            {
                return NotFound(); 
            }

            var engineType = _repository.ShopEngineType.GetEngineType(model.engineTypeId, trackChanges: false);
            var engineTypeDTO = _mapper.Map<EngineDTO>(engineType);
            return Ok(engineTypeDTO);
        }

        [HttpPost]
        public IActionResult CreateEngine([FromBody]EngineForCreationDTO engine)
        {
            if (engine == null)
            {
                return BadRequest("EngineForCreationDTO object send from client is null");
            }

            var engineEntity = _mapper.Map<ShopEngineType>(engine);
            _repository.ShopEngineType.CreateEngineType(engineEntity);
            _repository.Save();

            var engineTypeToReturn = _mapper.Map<EngineDTO>(engineEntity);
            return CreatedAtRoute("EngineById", new { id = engineTypeToReturn.id }, engineTypeToReturn);
        }
    }
}
