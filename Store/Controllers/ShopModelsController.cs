using AutoMapper;
using Contracts;
using Contracts.DataShape;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.IncludeDTO;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Store.ActionFilters;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    //[ResponseCache(CacheProfileName = "120SecondsDuration")]
    public class ShopModelsController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IDataShaper<ModelFullInfo> _dataShaper;

        public ShopModelsController(IRepositoryManager repository, IMapper mapper, IDataShaper<ModelFullInfo> dataShaper)
        {
            _repository = repository;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }

        [HttpGet]
        [HttpHead]
        //[HttpCacheExpiration(MaxAge = 120)]
        //[ResponseCache(Duration = 10, NoStore =true)]
        public async Task<IActionResult> GetModels([FromQuery] ModelsParameters modelsParameters)
        {
            if (!modelsParameters.ValidRange())
                return BadRequest("Max price can't be less than min price.");

            var models = await _repository.ShopModel.GetAllIncludesAsync(modelsParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(models.MetaData));
            return Ok(models);
        }

        [HttpGet("{id}", Name = "ModelById")]
        //[HttpCacheExpiration(CacheLocation = CacheLocation.Public, MaxAge = 60)]
        //[HttpCacheValidation(MustRevalidate = false)]
        public async Task<IActionResult> GetModel(int id)
        {
            var model = await _repository.ShopModel.GetModelFullInfo(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }
            //var modelDTO = _mapper.Map<ModelDto>(model);
            return Ok(model);
        }

        [HttpPost("shopMark/{markId}/shopEngine/{engineId}/shopCarcaseType/{carcaseId}/shopDriveType/{driveId}/shopTransmission/{transmissionId}/models")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateModel(int markId, int engineId, int carcaseId, int driveId, int transmissionId, [FromBody] ModelForCreationDto model)
        {
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

            var modelToReturn = _mapper.Map<ModelDto>(modelEntity);
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

            return NoContent();
        }
    }
}
