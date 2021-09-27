using Entities.DataTransferObjects.Order;
using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Threading.Tasks;

namespace Contracts.IShopRepository
{
    public interface IOrderRepository
    {
        Task<PagedEntity<Order>> GetOrders(QueryParams queryParams);
        Task<Order> GetOrder(Guid orderId);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);
        void GetOrdersStatistic(TimePeriod timePeriod);
        
    }
}
