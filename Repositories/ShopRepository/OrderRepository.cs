using Contracts.IShopRepository;
using Entities;
using Entities.DataTransferObjects.Order;
using Entities.Models;
using Entities.Models.Product;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
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
            Order[] orders = FindAll(trackChanges: false)
                .ToArray();

            return PagedEntity<Order>.ToPagedModels(orders, queryParams.PageNumber, queryParams.PageSize);

        }

        public void CreateOrder(Order order)
        {
            Create(order);
        }

        public async Task<Order> GetOrder(Guid orderId)
        {
            return FindByCondition(e => e.Id == orderId, trackChanges: true).SingleOrDefault();
        }

        public void DeleteOrder(Order order)
        {
            Delete(order);
        }

        public void GetOrdersStatistic(TimePeriod timePeriod)
        {
            Order[] orders = FindAll(false)
                .Include(e => e.ShopModel)
                .ThenInclude(e => e.Meshes)
                .ThenInclude(e => e.Ent)
                .ToArray();

            var groupByMarks = orders.GroupBy(e => e.ShopModel.Meshes.Where(s => s.Ent.Type == EntType.Mark).Select(t => t.Ent.Value).First())
                .Select(e => Tuple.Create(e.Key, e.Count()))
                .ToArray();

            var groupByCarcases = orders.GroupBy(e => e.ShopModel.Meshes.Where(s => s.Ent.Type == EntType.Carcase).Select(t => t.Ent.Value).FirstOrDefault())
                .Select(e => Tuple.Create(e.Key, e.Count()))
                .ToArray();

            var priceStatisticsForPeriod = orders
                .Where(e => e.OrderDateTime > DateTime.Now.AddDays(-(double)timePeriod))
                .Select(e => e.ShopModel.Price)
                .Sum();

            return;
        }
    }
}
