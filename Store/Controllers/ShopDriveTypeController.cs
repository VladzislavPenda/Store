using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.DriveDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store.ModelBinders;
using System.Collections.Generic;
using System.Linq;

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
        public IActionResult GetAllDriveTypes()
        {
            var driveTypes = _repository.ShopDriveType.GetAllDriveTypes(trackChanges: false);
            var driveDTO = _mapper.Map<IEnumerable<DriveDTO>>(driveTypes);
            return Ok(driveDTO);
        }

        [HttpGet("{id}", Name = "DriveTypeById")]
        public IActionResult GetDriveType(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var driveEntity = _repository.ShopDriveType.GetDriveType(model.driveTypeId, trackChanges: false);
            var driveDTO = _mapper.Map<DriveDTO>(driveEntity);
            return Ok(driveDTO);
        }

        [HttpGet("collection/({ids})", Name = "DriveCollection")]
        public IActionResult GetDriveCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var driveEntities = _repository.ShopDriveType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != driveEntities.Count())
            {
                return NotFound();
            }

            var driveToReturn = _mapper.Map<IEnumerable<DriveDTO>>(driveEntities);
            return Ok(driveToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateDriveCollection([FromBody] IEnumerable<DriveDTO> driveCollection)
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

            _repository.Save();
            var driveCollectionToReturn = _mapper.Map<IEnumerable<DriveDTO>>(driveEntities);
            var ids = string.Join(",", driveCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("DriveCollection", new { ids }, driveCollectionToReturn);
        }

        [HttpPost]
        public IActionResult CreateDriveType([FromBody]DriveForCreationDTO driveType)
        {
            if (driveType == null)
            {
                return BadRequest("driveForCreationDTO object send was null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var driveEntity = _mapper.Map<ShopDriveType>(driveType);
            _repository.ShopDriveType.CreateDriveType(driveEntity);
            _repository.Save();

            var driveTypeToReturn = _mapper.Map<DriveDTO>(driveEntity);
            return CreatedAtRoute("DriveTypeById", new { id = driveTypeToReturn.id }, driveTypeToReturn);
        }
    }
}
