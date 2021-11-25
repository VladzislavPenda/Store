using Contracts.IShopRepository;
using Entities;
using Entities.DataTransferObjects.Order;
using Entities.DataTransferObjects.OrderDto;
using Entities.DataTransferObjects.OrdersDto;
using Entities.Models;
using Entities.Models.Product;
using Entities.Models.Views;
using Entities.RequestFeatures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                .Include(e => e.ShopModel)
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

        public async Task<StorageStatisticDto> GetStorageStatistic()
        {
            var res = _repository.OrderStatisticViews.AsEnumerable().GroupBy(e => e.EntType);
            Dictionary<string, Stats[]> data = new Dictionary<string, Stats[]>();
            foreach (var item in res)
            {
                List<Stats> elem = new List<Stats>();
                foreach (var value in item)
                {
                    elem.Add(new Stats { Value = value.Value, Count = value.Count});
                }

                Stats[] statsArr = elem.ToArray();
                switch (item.Key)
                {
                    case 1: data.Add("carcase", statsArr); break;
                    case 2: data.Add("engine", statsArr); break;
                    case 3: data.Add("drive", statsArr); break;
                    case 4: data.Add("transmission", statsArr); break;
                    case 5: data.Add("mark", statsArr); break;
                }

            }

            IQueryable<Order> qry = FindAll(false)
                .Include(e => e.ShopModel)
                .ThenInclude(e => e.Meshes)
                .ThenInclude(e => e.Ent);

            int price = qry
                .Select(e => e.ShopModel.Price)
                .Sum();

            Order[] orders = await qry.ToArrayAsync();
            int orderCount = orders.Length;

            StorageStatisticDto stats = new StorageStatisticDto
            {
                OrdersCount = orderCount,
                TotalIncome = price,
                Stats = data,
            };

            return stats;
        }

        public async Task<IncomeStatisticDto> GetIncomeStatistic(TimePeriod timePeriod)
        {
            IQueryable<Order> qry = FindAll(false)
                .Include(e => e.ShopModel)
                .ThenInclude(e => e.Meshes)
                .ThenInclude(e => e.Ent);

            if (timePeriod != TimePeriod.ForAllTime)
            {
                qry = qry.Where(e => e.OrderDateTime > DateTime.Now.AddDays(-(double)timePeriod));
            }

            int price = qry
                .Select(e => e.ShopModel.Price)
                .Sum();

            Order[] orders = await qry.ToArrayAsync();
            int orderCount = orders.Length;
            var ents = qry.SelectMany(e => e.ShopModel.Meshes).Select(e => e.Ent).AsEnumerable().GroupBy(e => e.Type);
            Dictionary<EntType, IEnumerable<Stats>> data = new Dictionary<EntType, IEnumerable<Stats>>();

            foreach (var item in ents)
            {
                if (item.Key != EntType.Picture)
                {

                    List<Stats> statsList = new List<Stats>();

                    var group = item.GroupBy(e => e.Value).Select(e => new Stats { Value = e.Key, Count = e.Count() });
                    foreach (var value in item)
                    {
                        statsList.Add(new Stats { Value = value.Value });
                    }

                    data.Add(item.Key, group);
                }
            }

            return new IncomeStatisticDto() { TotalIncome = price, Stats = data, OrdersCount = orderCount };
        }
    }

    
}
