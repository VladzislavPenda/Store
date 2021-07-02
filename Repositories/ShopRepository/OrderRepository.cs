using Contracts.IShopRepository;
using Entities;
using Entities.DataTransferObjects.Order;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
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
    }
}
