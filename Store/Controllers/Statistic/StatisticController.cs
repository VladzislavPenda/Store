using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Order;
using Microsoft.AspNetCore.Mvc;
using Store.Server.Extensions;
using System.Linq;
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
        private readonly IMapper _mapper;
        private readonly ShopServices _services;

        public StatisticController(IRepositoryManager repository, IMapper mapper, ShopServices shopServices)
        {
            _repository = repository;
            _mapper = mapper;
            _services = shopServices;
        }

        [HttpGet("carType")]
        public async Task<IActionResult> GetCarTypeStatistic()
        {
            OrderStatisticDto stats = await _repository.Order.GetOrdersStatistic(Entities.RequestFeatures.TimePeriod.ForThisMounth);   
            return Ok(stats);
        }
    }
}
