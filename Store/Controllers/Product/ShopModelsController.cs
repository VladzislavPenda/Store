using AutoMapper;
using Contracts;
using Contracts.DataShape;
using Entities;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.IncludeDTO;
using Entities.DataTransferObjects.QueryModelDto;
using Entities.Models;
using Entities.Models.Product;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Store.ActionFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ShopModelsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IDataShaper<ModelFullInfo> _dataShaper;
        private readonly RepositoryContext _repositoryContext;

        public ShopModelsController(IRepositoryManager repository, IMapper mapper, IDataShaper<ModelFullInfo> dataShaper, RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _repository = repository;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetModelsWithParams([FromQuery] ModelsParameters modelsParameters)
        {
            if (!modelsParameters.ValidRange())
                return BadRequest("Max price can't be less than min price.");

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            PagedModels models = await _repository.ShopModel.GetPagedModelsWithParams(modelsParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(models.MetaData));
            string result = JsonSerializer.Serialize(models.Models, options);
            return Ok(result);
        }

        [HttpGet("{id}", Name = "ModelById")]
        public async Task<IActionResult> GetModel(Guid id)
        {
            ShopModel model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };

            string modelForResponse = JsonSerializer.Serialize(model, options);
            return Ok(modelForResponse);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateModel([FromBody] QueryModelForCreating model)
        {
            Guid storageId = await _repositoryContext.Storages
                .Where(e => e.Address == model.StorageAddress)
                .Select(e => e.Id)
                .SingleOrDefaultAsync();

            if (storageId == Guid.Empty)
                return Conflict();

            List<Ent> picturesEnts = new List<Ent>();
            foreach (var picture in model.Pictures)
                picturesEnts.Add(new Ent {
                    Type = EntType.Picture,
                    Value = picture
                });

            _repository.Ent.CreateEntRange(picturesEnts);
            await _repository.SaveAsync();

            Guid[] ents = await _repositoryContext.Ents
                .Where(e => model.Ents.Contains(e.Value) || model.Pictures.Contains(e.Value))
                .Select(e => e.Id)
                .ToArrayAsync();

            Guid modelId = Guid.NewGuid();
            List<Mesh> meshes = new List<Mesh>();
            foreach (var ent in ents)
                meshes.Add(new Mesh {
                   ModelId = modelId, 
                   EntId = ent
                });

            ShopModel shopModel = _mapper.Map<ShopModel>(model);
            _repository.ShopModel.CreateModel(shopModel, modelId, storageId);
            _repository.Mesh.CreateMeshRange(meshes);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(CreateModel), new { id = modelId }, shopModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModel(Guid id)
        {
            ShopModel model = await _repository.ShopModel.GetModel(id, trackChanges: true);
            if (model == null)
            {
                return NotFound();
            }

            Mesh[] meshes = await _repository.Mesh.GetMeshesForModel(model.Id, trackChanges: true);
            if(meshes != null)
                _repository.Mesh.DeleteMeshRange(meshes);

            _repository.ShopModel.DeleteModel(model);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateModel(Guid id, [FromBody]QueryModelForUpdating model)
        {
            ShopModel modelEntity = await _repository.ShopModel.GetModel(id, trackChanges: true);
            if (modelEntity == null)
            {
                return NotFound();
            }

            Mesh[] existingMeshes = await _repository.Mesh.GetMeshesForModel(modelEntity.Id, trackChanges: true);

            Guid[] entsToAdd = await _repositoryContext.Ents
                .Where(e => model.EntsToAdd.Contains(e.Value))
                .Select(e => e.Id)
                .ToArrayAsync();

            List<Mesh> meshesToAdd = new List<Mesh>();
            foreach (var ent in entsToAdd)
                meshesToAdd.Add(new Mesh
                {
                    ModelId = id,
                    EntId = ent
                });

            Guid[] entsToRemove = await _repositoryContext.Ents
                .Where(e => model.EntsToRemove.Contains(e.Value))
                .Select(e => e.Id)
                .ToArrayAsync();

            List<Mesh> meshesToRemove = new List<Mesh>();
            foreach (var ent in entsToRemove)
                meshesToAdd.Add(new Mesh
                {
                    ModelId = id,
                    EntId = ent
                });

            _repository.Mesh.CreateMeshRange(meshesToAdd);
            _repository.Mesh.DeleteMeshRange(meshesToRemove);

            _mapper.Map(model, modelEntity);
            await _repository.SaveAsync();

            return Ok();
        }
    }
    
    
}
