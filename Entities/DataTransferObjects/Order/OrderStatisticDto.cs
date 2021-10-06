using Entities.Models.Views;

namespace Entities.DataTransferObjects.Order
{
    public class OrderStatisticDto
    {
        public OrderStatistic[] Stats { get; set; }
        public int Price { get; set; }
    }
}
