using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.EntDto
{
    public class EntResponseDto
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public int Type { get; set; }
    }
}
