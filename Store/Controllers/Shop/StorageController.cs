using AutoMapper;
using Contracts;
using Entities.Models.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Store.Server.Controllers.Shop
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class StorageController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public StorageController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllStorages()
        {
            Storage[] storages = await _repository.Storage.GetStoragesAsync();

            if (storages == null)
                return NotFound();

            return Ok(storages);
        }

        [HttpGet("{storageId}")]
        public async Task<IActionResult> GetStorage(Guid storageId)
        {
            Storage storage = await _repository.Storage.GetStorageById(storageId);

            if (storage == null)
                return NotFound();

            return Ok(storage);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateStorage([FromBody] Storage storage) 
        {
            _repository.Storage.CreateStorage(storage);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(CreateStorage), new { id = storage.Id }, storage);
        }

        [HttpDelete("{storageId}")]
        public async Task<IActionResult> DeleteStorage(Guid storageId)
        {
            Storage storage = await _repository.Storage.GetStorageById(storageId);
            if (storage == null)
                return NotFound();

            if (storage.ShopModels.Count > 0)
               return Problem("There are cars in storage", statusCode: StatusCodes.Status405MethodNotAllowed);

            _repository.Storage.DeleteStorage(storage);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
