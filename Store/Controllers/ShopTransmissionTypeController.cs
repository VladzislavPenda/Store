using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.TransmissionDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store.ActionFilters;
using Store.ModelBinders;
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
        public async Task<IActionResult> GetTransmissionTypes()
        {
            var transmissionTypes = await _repository.ShopTransmissionType.GetAllTransmissionTypes(trackChanges: false);
            var transmissionTypesDTO = _mapper.Map<IEnumerable<TransmissionDto>>(transmissionTypes);
            return Ok(transmissionTypesDTO);
        }

        [HttpGet("{id}", Name = "TransmissionById")]
        public async Task<IActionResult> GetTransmissionForModel(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var transmissionType = await _repository.ShopTransmissionType.GetTransmissionType(model.transmissionId, trackChanges: false);
            var transmissionTypeDTO = _mapper.Map<TransmissionDto>(transmissionType);
            return Ok(transmissionTypeDTO);
        }

        [HttpGet("collection/({ids})", Name = "TransmissionCollection")]
        public async Task<IActionResult> GetTransmissionCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var transmissionEntities = await _repository.ShopTransmissionType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != transmissionEntities.Count())
            {
                return NotFound();
            }

            var transmissionToReturn = _mapper.Map<IEnumerable<TransmissionDto>>(transmissionEntities);
            return Ok(transmissionToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateTransmissionCollection([FromBody] IEnumerable<TransmissionDto> transmissionCollection)
        {
            if (transmissionCollection == null)
            {
                return BadRequest("transmissionCollection parameter was null");
            }

            var transmissionEntities = _mapper.Map<IEnumerable<ShopTransmissionType>>(transmissionCollection);
            foreach (var transmission in transmissionEntities)
            {
                _repository.ShopTransmissionType.CreateTransmissionType(transmission);
            }

            await _repository.SaveAsync();
            var transmissionCollectionToReturn = _mapper.Map<IEnumerable<TransmissionDto>>(transmissionEntities);
            var ids = string.Join(",", transmissionCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("TransmissionCollection", new { ids }, transmissionCollectionToReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateTransmission([FromBody]TransmissionForCreationDto transmission)
        {
            var transmissionEntity = _mapper.Map<ShopTransmissionType>(transmission);
            _repository.ShopTransmissionType.CreateTransmissionType(transmissionEntity);
            await _repository.SaveAsync();

            var transmissionTypeToReturn = _mapper.Map<TransmissionDto>(transmissionEntity);
            return CreatedAtRoute("TransmissionById", new { id = transmissionTypeToReturn.id }, transmissionTypeToReturn);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateTransmission(int id, [FromBody] TransmissionForUpdatingDto transmission)
        {
            var transmissionEntity = await _repository.ShopTransmissionType.GetTransmissionType(id, trackChanges: true);
            if (transmissionEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(transmission, transmissionEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
