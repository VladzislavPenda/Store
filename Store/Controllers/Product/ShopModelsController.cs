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
using Newtonsoft.Json;
using Store.ActionFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        public async Task<IActionResult> GetModels([FromQuery] ModelsParameters modelsParameters)
        {
            if (!modelsParameters.ValidRange())
                return BadRequest("Max price can't be less than min price.");
            List<ShopModel> a = await _repositoryContext.ShopModels
                .Include(e => e.Meshes)
                .ToListAsync();

            List<Ent> meshes = await _repositoryContext.Meshes
                .Include(e => e.Ent)
                //.Where(e => a.)
                .Select(e => new Ent
                {
                    Id = e.Ent.Id,
                    Type = e.Ent.Type,
                    Meshes = e.Ent.Meshes,
                    Value = e.Ent.Value
                }).ToListAsync();
                

            //var models = await _repository.ShopModel.GetAllIncludesAsync(modelsParameters, trackChanges: false);
            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(models.MetaData));
            return Ok();
        }

        [HttpGet("{id}", Name = "ModelById")]
        public async Task<IActionResult> GetModel(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }
            var modelDTO = _mapper.Map<ModelDto>(model);
            return Ok(model);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateModel([FromBody] QueryModelForCreating model)
        {
            Guid storageId = await _repositoryContext.Storages
                .Where(e => e.Address == model.StorageAddress)
                .Select(e => e.Id)
                .SingleOrDefaultAsync();

            Guid[] ents = await _repositoryContext.Ents
                .Where(e => model.Characteristics.Contains(e.Value))
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
            _repository.SaveAsync();
            return CreatedAtAction(nameof(CreateModel), new { id = modelId }, shopModel);
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateModel(int id, [FromBody]ModelForUpdatingDto model)
        {
            var modelEntity = await _repository.ShopModel.GetModel(id, trackChanges: true);
            if (modelEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(model, modelEntity);
            await _repository.SaveAsync();

            return Ok();
        }
    }
    
    
}
