using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.TransmissionDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopTransmissionTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ShopTransmissionTypeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransmissionTypes()
        {
            var transmissionTypes = _repository.ShopTransmissionType.GetAllTransmissionTypes(trackChanges: false);
            var transmissionTypesDTO = _mapper.Map<IEnumerable<TransmissionDTO>>(transmissionTypes);
            return Ok(transmissionTypesDTO);
        }

        [HttpGet("{id}", Name = "TransmissionById")]
        public IActionResult GetTransmissionForModel(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var transmissionType = _repository.ShopTransmissionType.GetTransmissionType(model.transmissionId, trackChanges: false);
            var transmissionTypeDTO = _mapper.Map<TransmissionDTO>(transmissionType);
            return Ok(transmissionTypeDTO);
        }

        [HttpPost]
        public IActionResult CreateTransmission([FromBody]TransmissionForCreationDTO transmission)
        {
            if (transmission == null)
            {
                return BadRequest("TransmissionForCreationDTO object send from client is null");
            }

            var transmissionEntity = _mapper.Map<ShopTransmissionType>(transmission);
            _repository.ShopTransmissionType.CreateTransmissionType(transmissionEntity);
            _repository.Save();

            var transmissionTypeToReturn = _mapper.Map<TransmissionDTO>(transmissionEntity);
            return CreatedAtRoute("TransmissionById", new { id = transmissionTypeToReturn.id }, transmissionTypeToReturn);
        }
    }
}
