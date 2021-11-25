using Entities.Models.Product;
using Entities.Models.Views;
using System.Collections.Generic;
using System.Linq;
//using Repositories.ShopRepository;

namespace Entities.DataTransferObjects.Order
{
    public class StorageStatisticDto
    {
        public int OrdersCount { get; set; }
        public int TotalIncome { get; set; }
        public Dictionary<string, Stats[]> Stats { get; set; }
        //public int Price { get; set; }
    }

    public class Stats
    {
        public string Value { get; set; }
        public int Count { get; set; }
    }
}
