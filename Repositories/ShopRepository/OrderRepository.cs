using Contracts.IShopRepository;
using Entities;
using Entities.DataTransferObjects.Order;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly RepositoryContext _repository;
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            _repository = repositoryContext;
        }
        public async Task<PagedEntity<Order>> GetOrders(QueryParams queryParams)
        {
            Order[] orders = await FindAll(trackChanges: false)
                .ToArrayAsync();

            return PagedEntity<Order>.ToPagedModels(orders, queryParams.PageNumber, queryParams.PageSize);

        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            return await FindByCondition(e => e.Id == orderId, trackChanges: true).SingleOrDefaultAsync();
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public async Task<OrderStatisticDto> GetOrdersStatistic(TimePeriod timePeriod)
        {
            Order[] orders = await FindAll(false)
                .Include(e => e.ShopModel)
                .ThenInclude(e => e.Meshes)
                .ThenInclude(e => e.Ent)
                .ToArrayAsync();

            int priceStatisticsForPeriod = orders
                .Where(e => e.OrderDateTime > DateTime.Now.AddDays(-(double)timePeriod))
                .Select(e => e.ShopModel.Price)
                .Sum();

            var res = await _repository.OrderStatisticViews.ToArrayAsync();
            OrderStatisticDto stats = new OrderStatisticDto
            {
                Stats = res,
                Price = priceStatisticsForPeriod,
            };

            return stats;
        }
    }
}
