﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopMarkController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ShopMarkController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMarks()
        {
            var marks = _repository.ShopMark.GetAllMarks(trackChanges: false);
            var models = _repository.ShopModel.GetAllShopModels(trackChanges: false);
            var modelsDTO = models.Select(c => new modelDTO
            {
                id = c.id,
                year = (int)c.year,
                transmissionId = c.transmissionId,
                driveTypeId = c.driveTypeId,
                carcaseTypeId = c.carcaseTypeId,
                engineTypeId = c.engineTypeId,
                markId = c.markId,
                horse_Power = (int)c.horse_power,
                mileAge = c.mileage,
                model = c.model,
                price = c.price
            }).ToList();
            //var modelsDTO = _mapper.Map<IEnumerable<modelDTO>>(models);
            return Ok(modelsDTO);   
        }

        //var companies = _repository.ShopModel.GetAllShopModels(trackChanges: false);
        //var marks = _repository.ShopMark.GetAllMarks(trackChanges: false);
        //var result = companies.Select(c => c.ShopMark.country);
        //_ = companies.Join(marks, a => a.MarkId, b => b.id, (a, b) => new { ModelId = a.id, num = b.id });

        [HttpGet("{id}")]
        public IActionResult GetMark(int id)
        {
            var mark = _repository.ShopMark.GetMark(id, trackChanges: false);
            if (mark == null)
            {
                return NotFound();
            }
            return Ok(mark);
        }

    }
}
