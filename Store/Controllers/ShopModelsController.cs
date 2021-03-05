using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopModelsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ShopModelsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetModels()
        {
            var models = _repository.ShopModel.GetAllShopModels(trackChanges: false);
            var modelsDTO = _mapper.Map<IEnumerable<ModelDTO>>(models);
            return Ok(modelsDTO);
        }

        [HttpGet("{id}", Name = "ModelById")]
        public IActionResult GetModel(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }
            var modelDTO = _mapper.Map<ModelDTO>(model);
            return Ok(modelDTO);
        }
    }
}
