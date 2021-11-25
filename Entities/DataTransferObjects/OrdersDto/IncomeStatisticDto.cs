using Entities.DataTransferObjects.Order;
using Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.OrdersDto
{
    public class IncomeStatisticDto
    {
        public int OrdersCount { get; set; }
        public int TotalIncome { get; set; }
        public Dictionary<EntType, IEnumerable<Stats>> Stats { get; set; }
    }
}
