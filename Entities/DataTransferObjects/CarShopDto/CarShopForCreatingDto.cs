using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.CarShopDto
{
    public class CarShopForCreatingDto
    {
        public string ShopName { get; set; }
        public string Adress { get; set; }
        public string ContactPhone { get; set; }
        public string Description { get; set; }
    }
}
