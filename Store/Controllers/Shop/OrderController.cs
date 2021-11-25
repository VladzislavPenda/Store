using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Order;
using Entities.DataTransferObjects.OrderDto;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Store.Server.Extensions;
using System;
using System.Net.Mime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Store.Server.Controllers.Shop
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("Shop")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class OrderController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly ShopServices _services;
        public OrderController(IRepositoryManager repositoryManager, IMapper mapper, ShopServices shopServices)
        {
            _repository = repositoryManager;
            _mapper = mapper;
            _services = shopServices;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] QueryParams qry)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            PagedEntity<Order> orders = await _repository.Order.GetOrders(qry);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(orders.MetaData));
            string result = JsonSerializer.Serialize(orders.Models, options);
            return Content(result, MediaTypeNames.Application.Json);
        }

        [Authorize]
        [HttpPost("{modelId}")]
        public async Task<IActionResult> Post(Guid modelId)
        {
            string accessToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            string userEmail = _services.GetUserEmail(accessToken);
            ShopModel shopModel = await _repository.ShopModel.GetModelAsync(modelId, trackChanges: true);

            if (shopModel == null)
                return NotFound();

            shopModel.NumberOfCar--;
            if (shopModel.NumberOfCar == 0)
            {
                shopModel.IsActive = false;
            }

            await _repository.SaveAsync();

            Order newOrder = new Order
            {
                ShopModelId = modelId,
                UserEmail = userEmail,
                OrderDateTime = DateTime.Now
            };

            _repository.Order.CreateOrder(newOrder);
            await _repository.SaveAsync();
            return CreatedAtAction(nameof(Post), new { id = modelId }, newOrder);
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(Guid orderId)
        {
            Order order = await _repository.Order.GetOrder(orderId);

            if (order == null)
                return NotFound();

            _repository.Order.DeleteOrder(order);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
