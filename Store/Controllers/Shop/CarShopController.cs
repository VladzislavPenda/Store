using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.CarShopDto;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarShopController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public CarShopController(IMapper mapper, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _repositoryManager = repositoryManager;
        }
        [HttpGet]
        public async Task<IActionResult> GetCarShops()
        {
            var carShops = await _repositoryManager.CarShop.GetAllShops(false);
            if (carShops == null)
            {
                return NotFound();
            }

            string result = JsonSerializer.Serialize(carShops);
            return Ok(result);
        }

        [HttpGet("{companyGuid}")]
        public async Task<IActionResult> GetShopWithEmployees(Guid companyGuid)
        {
            var shopEntity = await _repositoryManager.CarShop.GetShopWithEmployees(companyGuid, false);
            if (shopEntity == null)
            {
                return NotFound();
            }

            var options = new JsonSerializerOptions
            {
                //MaxDepth = 3,
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string result = JsonSerializer.Serialize(shopEntity, options);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarShop([FromBody] CarShopForCreatingDto carShop)
        {
            var shopEntity = _mapper.Map<CarShop>(carShop);
            _repositoryManager.CarShop.CreateShop(shopEntity);
            await _repositoryManager.SaveAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShopData(Guid id, [FromBody] CarShopForUpdatingDto carShop)
        {
            var shopEntity = await _repositoryManager.CarShop.GetShopById(id, true);
            if (shopEntity == null)
            {
                return NotFound();
            }
            _mapper.Map(carShop, shopEntity);
            await _repositoryManager.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(Guid id)
        {
            var shopEntity = await _repositoryManager.CarShop.GetShopById(id, trackChanges: false);
            if (shopEntity == null)
            {
                return NotFound();
            }
            _repositoryManager.CarShop.DeleteShop(shopEntity);
            await _repositoryManager.SaveAsync();
            return NoContent();
        }
    }
}
