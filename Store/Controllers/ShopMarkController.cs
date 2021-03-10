using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("{id}" , Name = "MarkById")]
        public IActionResult GetMarkForModel(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }
            var mark = _repository.ShopMark.GetMark(model.markId, trackChanges: false);
            var markDTO = _mapper.Map<MarkDTO>(mark);
            return Ok(markDTO);
        }

        [HttpPost]
        public IActionResult CreateMark([FromBody]MarkForCreationDTO mark)
        {
            if (mark == null)
            {
                return BadRequest("MarkForCreationDTO object send from client is null.");
            }

            var markEntity = _mapper.Map<ShopMark>(mark);
            _repository.ShopMark.CreateMark(markEntity);
            _repository.Save();

            var MarkToReturn = _mapper.Map<MarkDTO>(markEntity);
            return CreatedAtRoute("MarkById", new { id = MarkToReturn.id }, MarkToReturn);
        }

        [HttpGet]
        public IActionResult GetMarks()
        {
            var marks = _repository.ShopMark.GetAllMarks(trackChanges: false);
            var marksDTO = _mapper.Map<IEnumerable<MarkDTO>>(marks);
            return Ok(marksDTO);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetMark(int id)
        //{
        //    var mark = _repository.ShopMark.GetMark(id, trackChanges: false);
        //    if (mark == null)
        //    {
        //        return NotFound();
        //    }
        //    var markDTO = _mapper.Map<MarkDTO>(mark);
        //    return Ok(markDTO);
        //}

    }
}
