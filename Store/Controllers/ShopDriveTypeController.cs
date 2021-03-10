using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.DriveDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpPost]
        public IActionResult CreateDriveType([FromBody]DriveForCreationDTO driveType)
        {
            if (driveType == null)
            {
                return BadRequest("driveForCreationDTO object send was null");
            }

            var driveEntity = _mapper.Map<ShopDriveType>(driveType);
            _repository.ShopDriveType.CreateDriveType(driveEntity);
            _repository.Save();

            var driveTypeToReturn = _mapper.Map<DriveDTO>(driveEntity);
            return CreatedAtRoute("DriveTypeById", new { id = driveTypeToReturn.id }, driveTypeToReturn);
        }
    }
}
