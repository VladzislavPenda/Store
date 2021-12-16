using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.EntDto;
using Entities.Models.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Server.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class EntController : Controller
    {
        //private readonly RepositoryContext _repository;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public EntController(IRepositoryManager repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnts()
        {
            Dictionary<string, Ent[]> ents = _repository.Ent.GetEnts();

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string entsForResponse = JsonSerializer.Serialize(ents, options);
            //EntResponseDto[] dtos = _mapper.Map<EntResponseDto[]>(ents);
            return Content(entsForResponse, MediaTypeNames.Application.Json);
        }

        [HttpGet("{entType}")]
        public async Task<IActionResult> GetEnts(EntType entType)
        {
            Ent[] ents = await _repository.Ent.GetEntsByType(entType).ToArrayAsync();
            EntResponseDto[] dtos = _mapper.Map<EntResponseDto[]>(ents);
            return Ok(dtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnt([FromBody] EntCreateDto entCreateDto)
        {
            Ent ent = _mapper.Map<Ent>(entCreateDto);
            _repository.Ent.CreateEnt(ent);
            return CreatedAtAction(nameof(CreateEnt), new { id = ent.Id }, ent);
        }

        [HttpDelete("{entId}")]
        public async Task<IActionResult> DeleteEnt(Guid entId)
        {
            Ent ent = await _repository.Ent.GetEntById(entId);

            if (ent == null)
                return NotFound();

            _repository.Ent.DeleteEnt(ent);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
