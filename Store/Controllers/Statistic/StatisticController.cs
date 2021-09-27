using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Store.Server.Extensions;
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

        [HttpGet("carType")]
        public async Task<IActionResult> GetCarTypeStatistic()
        {
            var models = await _repository.ShopModel.GetAllShopModels(false);
            return Ok();
        }
    }
}
