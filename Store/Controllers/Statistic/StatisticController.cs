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

        [HttpGet("carType")]
        public async Task<IActionResult> GetCarTypeStatistic()
        {
            OrderStatisticDto stats = await _repository.Order.GetOrdersStatistic(Entities.RequestFeatures.TimePeriod.ForThisMounth);   
            return Ok(stats);
        }
    }
}
