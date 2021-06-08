using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Picture
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        [ForeignKey(nameof(ShopModel))]
        public int ShopModelId { get; set; }
        public ShopModel ShopModel { get; set; }
    }
}
