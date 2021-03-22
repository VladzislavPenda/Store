using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.DriveDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store.ActionFilters;
using Store.ModelBinders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopDriveTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ShopDriveTypeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDriveTypes()
        {
            var driveTypes = await _repository.ShopDriveType.GetAllDriveTypes(trackChanges: false);
            var driveDTO = _mapper.Map<IEnumerable<DriveDTO>>(driveTypes);
            return Ok(driveDTO);
        }

        [HttpGet("{id}", Name = "DriveTypeById")]
        public async Task<IActionResult> GetDriveType(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var driveEntity = await _repository.ShopDriveType.GetDriveType(model.driveTypeId, trackChanges: false);
            var driveDTO = _mapper.Map<DriveDTO>(driveEntity);
            return Ok(driveDTO);
        }

        [HttpGet("collection/({ids})", Name = "DriveCollection")]
        public async Task<IActionResult> GetDriveCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var driveEntities = await _repository.ShopDriveType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != driveEntities.Count())
            {
                return NotFound();
            }

            var driveToReturn = _mapper.Map<IEnumerable<DriveDTO>>(driveEntities);
            return Ok(driveToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateDriveCollection([FromBody] IEnumerable<DriveDTO> driveCollection)
        {
            if (driveCollection == null)
            {
                return BadRequest("driveCollection parameter was null");
            }

            var driveEntities = _mapper.Map<IEnumerable<ShopDriveType>>(driveCollection);
            foreach (var drive in driveEntities)
            {
                _repository.ShopDriveType.CreateDriveType(drive);
            }

            await _repository.SaveAsync();
            var driveCollectionToReturn = _mapper.Map<IEnumerable<DriveDTO>>(driveEntities);
            var ids = string.Join(",", driveCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("DriveCollection", new { ids }, driveCollectionToReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateDriveType([FromBody]DriveForCreationDTO driveType)
        {
            var driveEntity = _mapper.Map<ShopDriveType>(driveType);
            _repository.ShopDriveType.CreateDriveType(driveEntity);
            await _repository.SaveAsync();

            var driveTypeToReturn = _mapper.Map<DriveDTO>(driveEntity);
            return CreatedAtRoute("DriveTypeById", new { id = driveTypeToReturn.id }, driveTypeToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateDriveType(int id, [FromBody] DriveForUpdatingDTO drive)
        {
            var driveEntity = await _repository.ShopDriveType.GetDriveType(id, trackChanges: true);
            if (driveEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(drive, driveEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
