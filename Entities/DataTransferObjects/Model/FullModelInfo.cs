using Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.Model
{
    public class FullModelInfo
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public int Price { get; set; }
        public int? Year { get; set; }
        public int? HorsePower { get; set; }
        public Guid[] Photos { get; set; }
        public Characterstic[] Characteristics { get; set; }
    }

    public class Characterstic
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
