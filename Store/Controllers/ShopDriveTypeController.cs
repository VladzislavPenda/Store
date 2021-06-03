using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.DriveDTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
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
            var driveDTO = _mapper.Map<IEnumerable<DriveDto>>(driveTypes);
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

            var driveEntity = await _repository.ShopDriveType.GetDriveType(model.DriveTypeId, trackChanges: false);
            var driveDTO = _mapper.Map<DriveDto>(driveEntity);
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

            var driveToReturn = _mapper.Map<IEnumerable<DriveDto>>(driveEntities);
            return Ok(driveToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateDriveCollection([FromBody] IEnumerable<DriveDto> driveCollection)
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
            var driveCollectionToReturn = _mapper.Map<IEnumerable<DriveDto>>(driveEntities);
            var ids = string.Join(",", driveCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("DriveCollection", new { ids }, driveCollectionToReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateDriveType([FromBody]DriveForCreationDto driveType)
        {
            var driveEntity = _mapper.Map<ShopDriveType>(driveType);
            _repository.ShopDriveType.CreateDriveType(driveEntity);
            await _repository.SaveAsync();

            var driveTypeToReturn = _mapper.Map<DriveDto>(driveEntity);
            return CreatedAtRoute("DriveTypeById", new { id = driveTypeToReturn.id }, driveTypeToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateDriveType(int id, [FromBody] DriveForUpdatingDto drive)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriveType(int id)
        {
            var drive = await _repository.ShopDriveType.GetDriveType(id, trackChanges: false);
            if (drive == null)
            {
                return NotFound();
            }

            _repository.ShopDriveType.DeleteDriveType(drive);
            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
