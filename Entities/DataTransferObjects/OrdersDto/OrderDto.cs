using Entities.DataTransferObjects.Model;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.OrdersDto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Guid ShopModelId { get; set; }
        //public ModelShortDto ShopModel { get; set; }
    }
}
