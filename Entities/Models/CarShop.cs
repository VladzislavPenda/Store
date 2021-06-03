using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CarShop
    {
        public Guid Id { get; set; }
        public string ShopName { get; set; }
        public string Adress { get; set; }
        public string ContactPhone { get; set; }
        public string Description { get; set; }
        public ICollection<ShopModel> ShopModels { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
