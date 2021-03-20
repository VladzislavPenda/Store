using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/[controller]")] // Возможно нужно будет заменить маршрут
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
        public async Task<IActionResult> GetModels()
        {
            var models = await _repository.ShopModel.GetAllShopModels(trackChanges: false);
            //var models = _repository.ShopModel.GetAllIncludes(trackChanges: false);
            var modelsDTO = _mapper.Map<IEnumerable<ModelDTO>>(models);
            
            
            return Ok(modelsDTO);
        }

        [HttpGet("{id}", Name = "ModelById")]
        public async Task<IActionResult> GetModel(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }
            var modelDTO = _mapper.Map<ModelDTO>(model);
            return Ok(modelDTO);
        }
        // Не уверен что так оно должно быть, тут надо еще подумать...
        [HttpPost("shopMark/{markId}/shopEngine/{engineId}/shopCarcaseType/{carcaseId}/shopDriveType/{driveId}/shopTransmission/{transmissionId}/models")]
        public async Task<IActionResult> CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, [FromBody] ModelForCreationDTO model)
        {
            if (model == null)
            {
                return BadRequest("modelForCreationDTO object was null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var mark = await _repository.ShopMark.GetMark(markId, trackChanges: false);
            var engine = await _repository.ShopEngineType.GetEngineType(engineId, trackChanges: false);
            var carcase = await _repository.ShopCarcaseType.GetCarcaseType(carcaseId, trackChanges: false);
            var drive = await _repository.ShopDriveType.GetDriveType(driveId, trackChanges: false);
            var transmission = await _repository.ShopTransmissionType.GetTransmissionType(transmissionId, trackChanges: false);

            if (mark == null || engine == null || carcase == null || drive == null || transmission == null)
            {
                return NotFound();
            }

            var modelEntity = _mapper.Map<ShopModel>(model);

            _repository.ShopModel.CreateModel(markId, engineId, carcaseId, driveId, transmissionId, modelEntity);
            await _repository.SaveAsync();

            var modelToReturn = _mapper.Map<ModelDTO>(modelEntity);
            return CreatedAtRoute("ModelById",
                new { markId, engineId, carcaseId, driveId, transmissionId, modelEntity, id = modelToReturn.id }, modelToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            _repository.ShopModel.DeleteModel(model);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModel(int id, [FromBody]ModelForUpdatingDTO model)
        {
            if (model == null)
            {
                return BadRequest("model object is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var modelEntity = await _repository.ShopModel.GetModel(id, trackChanges: true);
            if (modelEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(model, modelEntity);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
