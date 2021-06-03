using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserEmail { get; set; }
        public DateTime OrderDateTime { get; set; }
        [ForeignKey(nameof(ShopModel))]
        public int ShopModelId { get; set; }
        public ShopModel ShopModel { get; set; }
    }
}
