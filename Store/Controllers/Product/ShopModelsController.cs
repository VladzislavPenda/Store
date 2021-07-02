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
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.ActionFilters;
using System;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Entities.DataTransferObjects.EntDto;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Query;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ShopModelsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly RepositoryContext _repositoryContext;

        public ShopModelsController(IRepositoryManager repository, IMapper mapper, RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
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
            Guid storageId = await _repository.Storage.GetStorageByAddress(model.StorageAddress);

            if (storageId == Guid.Empty)
                return Conflict();

            Guid[] ents = await _repository.Ent.GetGuidsForCreatingQueryParams(model);

            if (model.Pictures != null)
            {
                Ent[] pictureEnts = new Ent[model.Pictures.Length];

                for (int i = 0; i < pictureEnts.Length; i++)
                {
                    pictureEnts[i] = new Ent
                    {
                        Id = Guid.NewGuid(),
                        Type = EntType.Picture,
                        Value = model.Pictures[i]
                    };
                }

                _repository.Ent.CreateEntRange(pictureEnts);
                await _repository.SaveAsync();

                Guid[] pictureGuids = pictureEnts.Select(e => e.Id).ToArray();
                ents = pictureGuids.Concat(ents).ToArray();
            }
            
            Guid modelId = Guid.NewGuid();
            Mesh[] mesh = new Mesh[ents.Length];
            for (int i = 0; i < mesh.Length; i++)
            {
                mesh[i] = new Mesh
                {
                    ModelId = modelId,
                    EntId = ents[i]
                };
            }

            ShopModel shopModel = _mapper.Map<ShopModel>(model);
            _repository.ShopModel.CreateModel(shopModel, modelId, storageId);
            _repository.Mesh.CreateMeshRange(mesh);
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

            Guid[] entsToAdd = await _repositoryContext.Ents
                .Where(e => model.EntsToAdd.Contains(e.Value))
                .AsNoTracking()
                .Select(e => e.Id)
                .ToArrayAsync();

            Mesh[] meshToAdd = new Mesh[entsToAdd.Length];
            for (int i = 0; i < meshToAdd.Length; i++)
            {
                meshToAdd[i] = new Mesh
                {
                    ModelId = id,
                    EntId = entsToAdd[i]
                };
            }

            Guid[] entsToRemove = await _repositoryContext.Ents
                .Where(e => model.EntsToRemove.Contains(e.Value))
                .AsNoTracking()
                .Select(e => e.Id)
                .ToArrayAsync();

            Mesh[] meshesToRemove = new Mesh[entsToRemove.Length];
            for (int i = 0; i < meshesToRemove.Length; i++)
            {
                meshesToRemove[i] = new Mesh
                {
                    ModelId = id,
                    EntId = entsToRemove[i]
                };
            }

            foreach (Mesh mesh in meshesToRemove)
            {
                Mesh meshToRemove = modelEntity.Meshes.Where(e => e.ModelId == mesh.ModelId && e.EntId == mesh.EntId).SingleOrDefault();
                if (meshToRemove != null)
                    modelEntity.Meshes.Remove(meshToRemove);
            }

            foreach (Mesh mesh in meshToAdd)
            {
                modelEntity.Meshes.Add(mesh);
            }

            _mapper.Map(model, modelEntity);
            await _repository.SaveAsync();
            return Ok();
        }
    }
    
    
}
