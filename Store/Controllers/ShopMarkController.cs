using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Store.ModelBinders;
using System.Collections.Generic;
using System.Linq;

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

        [HttpGet("collection/({ids})", Name ="MarkCollection")]
        public IActionResult GetMarkCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var markEntities = _repository.ShopMark.GetByIds(ids, trackChanges: false);

            if (ids.Count() != markEntities.Count())
            {
                return NotFound();
            }

            var marksToReturn = _mapper.Map<IEnumerable<MarkDTO>>(markEntities);
            return Ok(marksToReturn);
        }

        [HttpPost("collection")]
        public IActionResult CreateMerkCollection([FromBody]IEnumerable<MarkDTO> markCollection)
        {
            if (markCollection == null)
            {
                return BadRequest("markCollection parameter was null");
            }

            var markEntities = _mapper.Map<IEnumerable<ShopMark>>(markCollection);
            foreach (var mark in markEntities)
            {
                _repository.ShopMark.CreateMark(mark);
            }

            _repository.Save();
            var marksCollectionToReturn = _mapper.Map<IEnumerable<MarkDTO>>(markEntities);
            var ids = string.Join(",", marksCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("MarkCollection", new { ids }, marksCollectionToReturn);
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
    }
}
