using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Storages;
using Entities.Models.Shop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
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

            StorageDto[] result = _mapper.Map<Storage[], StorageDto[]>(storages);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            string response = JsonSerializer.Serialize(result, options);

            return Content(response, MediaTypeNames.Application.Json);
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
