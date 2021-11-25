using Contracts;
using Entities.DataTransferObjects.Order;
using Entities.DataTransferObjects.OrdersDto;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Server.Controllers.Statistic
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Statistic")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class StatisticController : Controller
    {
        private readonly IRepositoryManager _repository;

        public StatisticController(IRepositoryManager repository)
        {
            _repository = repository;
        }

        [HttpGet("storage")]
        public async Task<IActionResult> GetStorageStatistic()
        {
            StorageStatisticDto stats = await _repository.Order.GetStorageStatistic();
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };


            string content = JsonSerializer.Serialize(stats, options);
            return Content(content, MediaTypeNames.Application.Json);
            //return Ok(stats);
        }

        [HttpGet("income")]
        public async Task<IActionResult> GetTimeStatistic()
        {
            IncomeStatisticDto stats = await _repository.Order.GetIncomeStatistic(Entities.RequestFeatures.TimePeriod.ForYear);

            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
            };


            string content = JsonSerializer.Serialize(stats, options);
            return Content(content, MediaTypeNames.Application.Json);
            //return Ok(stats);
        }
    }
}
