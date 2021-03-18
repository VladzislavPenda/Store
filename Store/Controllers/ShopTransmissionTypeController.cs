﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.TransmissionDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("collection/({ids})", Name = "TransmissionCollection")]
        public IActionResult GetTransmissionCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))] IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var transmissionEntities = _repository.ShopTransmissionType.GetByIds(ids, trackChanges: false);

            if (ids.Count() != transmissionEntities.Count())
            {
                return NotFound();
            }

            var transmissionToReturn = _mapper.Map<IEnumerable<TransmissionDTO>>(transmissionEntities);
            return Ok(transmissionToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateTransmissionCollection([FromBody] IEnumerable<TransmissionDTO> transmissionCollection)
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

            _repository.Save();
            var transmissionCollectionToReturn = _mapper.Map<IEnumerable<TransmissionDTO>>(transmissionEntities);
            var ids = string.Join(",", transmissionCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("TransmissionCollection", new { ids }, transmissionCollectionToReturn);
        }

        [HttpPost]
        public IActionResult CreateTransmission([FromBody]TransmissionForCreationDTO transmission)
        {
            if (transmission == null)
            {
                return BadRequest("TransmissionForCreationDTO object send from client is null");
            }

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            var transmissionEntity = _mapper.Map<ShopTransmissionType>(transmission);
            _repository.ShopTransmissionType.CreateTransmissionType(transmissionEntity);
            _repository.Save();

            var transmissionTypeToReturn = _mapper.Map<TransmissionDTO>(transmissionEntity);
            return CreatedAtRoute("TransmissionById", new { id = transmissionTypeToReturn.id }, transmissionTypeToReturn);
        }
    }
}
