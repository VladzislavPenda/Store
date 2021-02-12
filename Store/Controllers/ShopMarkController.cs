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
        public IActionResult GetCompanies()
        {
            var companies = _repository.ShopMark.GetAllMarks(trackChanges: false);
            return Ok(companies);   
        }

    }
}
