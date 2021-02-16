using Contracts;
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

        public ShopMarkController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetMarks()
        {
            var marks = _repository.ShopMark.GetAllMarks(trackChanges: false);
            var companies = _repository.ShopModel.GetAllShopModels(trackChanges: false);

            return Ok(companies);   
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
