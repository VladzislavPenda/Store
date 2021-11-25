using Entities.DataTransferObjects.Order;
using Entities.DataTransferObjects.OrderDto;
using Entities.DataTransferObjects.OrdersDto;
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
        Task<StorageStatisticDto> GetStorageStatistic();
        Task<IncomeStatisticDto> GetIncomeStatistic(TimePeriod timePeriod);
        
    }
}
