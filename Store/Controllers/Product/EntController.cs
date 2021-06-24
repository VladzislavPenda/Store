using AutoMapper;
using Entities;
using Entities.DataTransferObjects.EntDto;
using Entities.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Server.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EntController : Controller
    {
        private readonly RepositoryContext _repository;
        private readonly IMapper _mapper;
        public EntController(RepositoryContext repositoryContext, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repositoryContext; 
        }
        
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] EntType entType)
        {
            Ent[] ents = await _repository.Ents
                .Where(e => e.Type == entType)
                .ToArrayAsync();

            EntResponseDto[] dtos = _mapper.Map<EntResponseDto[]>(ents);
            return Ok(dtos);
        }
    }
}
