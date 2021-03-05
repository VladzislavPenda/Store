using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.EngineDTO;
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

        [HttpGet("{id}")]
        public IActionResult GetEngineForModel(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null) 
            {
                return NotFound(); 
            }

            var engineType = _repository.ShopEngineType.GetEngineType(model.id, trackChanges: false);
            var engineTypeDTO = _mapper.Map<EngineDTO>(engineType);
            return Ok(engineTypeDTO);
        }
    }
}
