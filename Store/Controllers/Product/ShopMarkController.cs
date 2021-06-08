using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.MarkDTO;
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
        public async Task<IActionResult> GetMarks()
        {
            var marks = await _repository.ShopMark.GetAllMarks(trackChanges: false);
            var marksDTO = _mapper.Map<IEnumerable<MarkDto>>(marks);
            return Ok(marksDTO);
        }

        [HttpGet("{id}" , Name = "MarkById")]
        public async Task<IActionResult> GetMarkForModel(int id)
        {
            var model = await _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }
            var mark = await _repository.ShopMark.GetMark(model.MarkId, trackChanges: false);
            var markDTO = _mapper.Map<MarkDto>(mark);
            return Ok(markDTO);
        }

        [HttpGet("collection/({ids})", Name ="MarkCollection")]
        public async Task<IActionResult> GetMarkCollection([ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<int> ids)
        {
            if (ids == null)
            {
                return BadRequest("ids parameter was null");
            }

            var markEntities = await _repository.ShopMark.GetByIds(ids, trackChanges: false);

            if (ids.Count() != markEntities.Count())
            {
                return NotFound();
            }

            var marksToReturn = _mapper.Map<IEnumerable<MarkDto>>(markEntities);
            return Ok(marksToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreateMerkCollection([FromBody]IEnumerable<MarkDto> markCollection)
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


            await _repository.SaveAsync();
            var marksCollectionToReturn = _mapper.Map<IEnumerable<MarkDto>>(markEntities);
            var ids = string.Join(",", marksCollectionToReturn.Select(c => c.id));

            return CreatedAtRoute("MarkCollection", new { ids }, marksCollectionToReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateMark([FromBody]MarkForCreationDto mark)
        {
            var markEntity = _mapper.Map<ShopMark>(mark);
            _repository.ShopMark.CreateMark(markEntity);
            await _repository.SaveAsync();

            var MarkToReturn = _mapper.Map<MarkDto>(markEntity);
            return CreatedAtRoute("MarkById", new { id = MarkToReturn.id }, MarkToReturn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMark(int id)
        {
            var mark = await _repository.ShopMark.GetMark(id, trackChanges: false);
            if (mark == null)
            {
                return NotFound();
            }

            _repository.ShopMark.DeleteMark(mark);
            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateMark(int id, [FromBody] MarkForUpdatingDto mark)
        {
            var markEntity = await _repository.ShopMark.GetMark(id, trackChanges: true);
            if (markEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(mark, markEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
