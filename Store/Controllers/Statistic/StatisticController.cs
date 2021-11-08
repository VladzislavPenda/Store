using Contracts;
using Entities.DataTransferObjects.Order;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(stats);
        }

        [HttpGet("income")]
        public async Task<IActionResult> GetTimeStatistic()
        {
            IncomeStatisticDto stats = await _repository.Order.GetIncomeStatistic(Entities.RequestFeatures.TimePeriod.ForYear);
            return Ok(stats);
        }
    }
}
